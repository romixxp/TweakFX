using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

public class VBCableAudioSender : IDisposable
{
    private IWavePlayer waveOut;
    private BufferedWaveProvider bufferProvider;
    private BlockingCollection<byte[]> audioQueue;
    private CancellationTokenSource cts;
    private Task processingTask;
    private readonly WaveFormat waveFormat;

    public VBCableAudioSender(int sampleRate = 44100, int channels = 2, int bitsPerSample = 16)
    {
        waveFormat = new WaveFormat(sampleRate, bitsPerSample, channels);

        var deviceNumber = FindVBCableOutputDevice();
        if (deviceNumber == -1)
            throw new Exception("VB-Cable Output (playback device) not found.");

        waveOut = new WaveOutEvent
        {
            DeviceNumber = deviceNumber,
            DesiredLatency = 100
        };

        bufferProvider = new BufferedWaveProvider(waveFormat)
        {
            DiscardOnBufferOverflow = true,
            BufferDuration = TimeSpan.FromSeconds(5)
        };

        waveOut.Init(bufferProvider);
        waveOut.Play();

        audioQueue = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
        cts = new CancellationTokenSource();
        processingTask = Task.Run(() => ProcessQueue(cts.Token));
    }

    private int FindVBCableOutputDevice()
    {
        for (int i = 0; i < WaveOut.DeviceCount; i++)
        {
            var capabilities = WaveOut.GetCapabilities(i);
            Debug.WriteLine($"[Output #{i}] {capabilities.ProductName}");
        }

        for (int i = 0; i < WaveOut.DeviceCount; i++)
        {
            var capabilities = WaveOut.GetCapabilities(i);
            if (capabilities.ProductName.Contains("Cable In", StringComparison.OrdinalIgnoreCase))
            {
                Debug.WriteLine($"Output: {capabilities.ProductName}");
                return i;
            }
        }
        return -1;
    }

    public void SendBuffer(byte[] buffer)
    {
        if (!audioQueue.IsAddingCompleted)
        {
            //for (int i = 0; i < buffer.Length; i++)
            //    buffer[i] = (byte)(buffer[i] * volume);
            audioQueue.Add(buffer);
        }
    }

    

    private void ProcessQueue(CancellationToken token)
    {
        try
        {
            foreach (var buffer in audioQueue.GetConsumingEnumerable(token))
            {
                bufferProvider.AddSamples(buffer, 0, buffer.Length);
            }
        }
        catch (OperationCanceledException) { }
    }

    public void Dispose()
    {
        audioQueue.CompleteAdding();
        cts.Cancel();

        try { processingTask.Wait(); } catch { }

        waveOut?.Stop();
        waveOut?.Dispose();
        cts?.Dispose();
        audioQueue?.Dispose();
    }
}

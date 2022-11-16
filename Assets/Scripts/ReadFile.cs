using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class ReadFile
{
    private string _dataPath;
    private CancellationToken _token;
    private SemaphoreSlim _semaphore;

    public ReadFile(string dataPath, CancellationToken token, SemaphoreSlim semaphore)
    {
        _dataPath = dataPath;
        _token = token;
        _semaphore = semaphore;
    }

    public async void Read()
    {
        while (!_token.IsCancellationRequested)
        {
            if (File.Exists(_dataPath))
            {
                _semaphore.Wait();

                StreamReader reader = new StreamReader(_dataPath);
                UnityEngine.Debug.Log(reader.ReadToEnd());
                reader.Close();

                _semaphore.Release();
            }

            await Task.Delay(20000);
        }
    }
}

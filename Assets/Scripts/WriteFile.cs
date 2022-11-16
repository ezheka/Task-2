using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class WriteFile 
{
    private SemaphoreSlim _semaphore;
    private string _dataPath;

    public WriteFile(string dataPath, SemaphoreSlim semaphore)
    {
        _dataPath = dataPath;
        _semaphore = semaphore;
    }

    public void Write(string text)
    {
        _semaphore.Wait();

        StreamWriter writer;

        if (!File.Exists(_dataPath))
        {
            writer = new StreamWriter(_dataPath);
            writer.Close();
        }

        Task task = Task.Run(async () => {

            writer = new StreamWriter(_dataPath, true);
            await writer.WriteLineAsync(text);
            writer.Close();

        });

        _semaphore.Release();
    }
}

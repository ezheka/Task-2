using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class WriteFile 
{
    public async void Write(string dataPath, string text)
    {
        StreamWriter writer;

        if (!File.Exists(dataPath))
        {
            writer = new StreamWriter(dataPath);
            writer.Close();
        }

        writer = new StreamWriter(dataPath, true);
        await writer.WriteLineAsync(text);
        writer.Close();
    }
}

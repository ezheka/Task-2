using System.IO;
using System.Threading.Tasks;

public class ReadFile
{
    private bool isRead;

    public void StartRead(string dataPath)
    {
        isRead = true;
        Read(dataPath);
    }

    public void StopRead()
    {
        isRead = false;
    }

    private async void Read(string dataPath)
    {
        while (isRead)
        {
            if (File.Exists(dataPath))
            {
                StreamReader reader = new StreamReader(dataPath);
                UnityEngine.Debug.Log(reader.ReadToEnd());
                reader.Close();
            }

            await Task.Delay(20000);
        }
    }
}

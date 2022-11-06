using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    private string playerDataPath;

    private ReadFile readFile;
    private WriteFile writeFile;

    private void Start()
    {
        if (uiController == null)
            uiController = FindObjectOfType<UIController>();

        uiController.SetFileController(this);

        playerDataPath = "Assets/Resources/Data.txt";

        readFile = new ReadFile();
        readFile.StartRead(playerDataPath);
    }

    public void WriteFile(string text)
    {
        writeFile = new WriteFile();
        writeFile.Write(playerDataPath, text);      
    }

    private void OnApplicationQuit()
    {
        readFile.StopRead();
    }
}

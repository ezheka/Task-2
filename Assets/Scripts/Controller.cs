using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    private string playerDataPath;

    private ReadFile readFile;
    private WriteFile writeFile;

    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    CancellationToken _tokenRead;

    private SemaphoreSlim semaphore = new SemaphoreSlim(1);


    private void Start()
    {
        if (uiController == null)
            uiController = FindObjectOfType<UIController>();

        uiController.SetFileController(this);

        playerDataPath = Path.Combine("Assets/", "Resources/", "Data.txt");

        _tokenRead = _cancellationTokenSource.Token;
        readFile = new ReadFile(playerDataPath, _tokenRead, semaphore);
        Task.Run(readFile.Read);
    }

    public void WriteFile(string text)
    {
        writeFile = new WriteFile(playerDataPath, semaphore);
        writeFile.Write(text);      
    }

    private void OnApplicationQuit()
    {
        _cancellationTokenSource.Cancel();
    }
}

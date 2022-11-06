using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button buttonSetText;
    [SerializeField] private TMP_InputField inputFieldRead;

    private Controller _controller;
    public void SetFileController(Controller controller) => _controller = controller;


    private void Start()
    {
        buttonSetText.onClick.AddListener(SetText);
    }

    public void SetText()
    {
        if (!String.IsNullOrEmpty(inputFieldRead.text))
            _controller.WriteFile(inputFieldRead.text);

        inputFieldRead.text = "";
    }
}

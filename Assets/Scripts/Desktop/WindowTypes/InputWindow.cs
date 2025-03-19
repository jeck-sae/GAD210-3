using System;
using TMPro;
using UnityEngine;

public class InputWindow : WindowBehaviour
{
    [SerializeField] TMP_Text prompt;
    [SerializeField] TMP_InputField inputField;

    public Action<InputWindow, string> EnteredInput;

    InputWindowInfo info;

    public override void Initialize(WindowInfo info)
    {
        this.info = (InputWindowInfo)info;
        prompt.text = this.info.prompt;
    }

    private void OnEnable()
    {
        inputField.onSubmit.AddListener(OnEnterInput);
    }

    private void OnDisable()
    {
        inputField.onSubmit.RemoveListener(OnEnterInput);
    }

    public void OnEnterInput(string text)
    {
        EnteredInput?.Invoke(this, text);

        if (!string.IsNullOrEmpty(info.correctCode) && info.correctCode == text)
        {
            WindowManager.Instance.OpenWindow(info.openWindowWithCorrectCode);
            WindowManager.Instance.CloseWindow(info.windowName);
        }
    }

    public void ClearInputField()
    {
        inputField.text = "";
    }


}

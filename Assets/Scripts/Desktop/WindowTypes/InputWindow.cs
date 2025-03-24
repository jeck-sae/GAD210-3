using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(!string.IsNullOrEmpty(info.loadSceneOnCorrectCode))
                SceneManager.LoadScene(info.loadSceneOnCorrectCode);
            
            if(info.openWindowWithCorrectCode)
                WindowManager.Instance.OpenWindow(info.openWindowWithCorrectCode);
            
            if(info.closeWindowOnEnterCorrectCode)
                WindowManager.Instance.CloseWindow(info.windowName, true);
            
            ClearInputField();
        }
    }

    public void ClearInputField()
    {
        inputField.text = "";
    }


}

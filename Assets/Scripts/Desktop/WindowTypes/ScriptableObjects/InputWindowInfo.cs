using UnityEngine;

[CreateAssetMenu(menuName = "DesktopWindows/InputWindow", fileName = "InputWindow")]
public class InputWindowInfo : WindowInfo
{
    public string prompt;

    public string correctCode;
    public bool closeWindowOnEnterCorrectCode = true;
    public WindowInfo openWindowWithCorrectCode;
    public string loadSceneOnCorrectCode;
}

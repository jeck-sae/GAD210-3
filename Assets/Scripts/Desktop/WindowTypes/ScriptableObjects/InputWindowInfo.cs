using UnityEngine;

[CreateAssetMenu(menuName = "DesktopWindows/InputWindow", fileName = "InputWindow")]
public class InputWindowInfo : WindowInfo
{
    public string prompt;

    public string correctCode;
    public WindowInfo openWindowWithCorrectCode;
}

using UnityEngine;

[CreateAssetMenu(menuName = "DesktopWindows/TextWindow", fileName = "TextWindow")]
public class TextWindowInfo : WindowInfo
{
    [TextArea]
    public string text;
}

using TMPro;
using UnityEngine;

public class TextWindow : WindowBehaviour
{
    [SerializeField] TMP_Text text;

    public override void Initialize(WindowInfo info)
    {
        TextWindowInfo textInfo = info as TextWindowInfo;
        text.text = textInfo.text;
    }
}

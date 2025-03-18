using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageWindow : WindowBehaviour
{
    [SerializeField] Image image;

    public override void Initialize(WindowInfo info)
    {
        ImageWindowInfo imageInfo = info as ImageWindowInfo;
        image.sprite = imageInfo.image;
    }
}

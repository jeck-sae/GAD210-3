using UnityEngine;
using UnityEngine.UI;

public class TaskbarIcon : MonoBehaviour
{
    public DesktopWindow window;

    [SerializeField] Image image;

    public void Initialize(DesktopWindow window)
    {
        this.window = window;
        image.sprite = window.Info.icon;
    }

    public void OnClick()
    {
        window.Open();
    }
}

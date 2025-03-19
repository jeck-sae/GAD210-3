using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopWindow : MonoBehaviour
{
    public WindowInfo Info => info;
    WindowInfo info;
    public string WindowName => info.windowName;
    public bool IsMinimized => isMinimized;
    bool isMinimized;

    [SerializeField] TMP_Text windowNameText;
    [SerializeField] Image windowIcon;

    RectTransform rectTransform;

    public virtual void Initialize(WindowInfo info)
    {
        rectTransform = GetComponent<RectTransform>();
        this.info = info;
        windowNameText.text = info.windowName;
        windowIcon.sprite = info.icon;

        GetComponent<WindowBehaviour>().Initialize(info);
    }


    public void Close()
    {
        WindowManager.Instance.CloseWindow(info.windowName);
        Destroy(gameObject);
    }
    public void Open()
    {
        WindowManager.Instance.FocusWindow(this);
        gameObject.SetActive(true);
    }
    public void Minimize()
    {
        gameObject.SetActive(false);
    }


    Vector2 lastMousePosition;
    public void ClickedWindowBar()
    {
        lastMousePosition = Input.mousePosition;
    }

    public void Drag()
    {
        Vector2 delta = (Vector2)Input.mousePosition - lastMousePosition;
        rectTransform.anchoredPosition += delta;
        lastMousePosition = Input.mousePosition;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileIcon : MonoBehaviour
{
    protected const float DOUBLE_CLICK_MAX_DELAY = 0.25f;
    [SerializeField] WindowInfo info;

    [SerializeField] TMP_Text fileName;
    [SerializeField] Image icon;
    
    private void Start()
    {
        if(info != null)
            Initialize(info);
    }

    public void Initialize(WindowInfo info)
    {
        this.info = info;
        fileName.text = info.windowName;
        icon.sprite = info.icon;
    }

    float lastClickTime = 0;
    public void Click()
    {
        if (Time.time - lastClickTime > DOUBLE_CLICK_MAX_DELAY)
        {
            lastClickTime = Time.time;
            return;
        }
        if (info == null)
            return;

        WindowManager.Instance.OpenWindow(info);
    }
}

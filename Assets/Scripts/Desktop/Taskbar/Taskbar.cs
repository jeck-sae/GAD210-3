using System.Collections.Generic;
using UnityEngine;

public class Taskbar : MonoBehaviour
{
    [SerializeField] GameObject iconPrefab;
    [SerializeField] Transform iconsParent;

    List<TaskbarIcon> icons = new();

    private void Awake()
    {
        WindowManager.Instance.OnWindowOpened += AddIcon;
        WindowManager.Instance.OnWindowClosed += RemoveIcon;
    }


    protected void AddIcon(DesktopWindow window)
    {
        var go = Instantiate(iconPrefab);
        go.transform.SetParent(iconsParent, false);
        var icon = go.GetComponent<TaskbarIcon>();
        icon.Initialize(window);
        icons.Add(icon);
    }
    protected void RemoveIcon(DesktopWindow window)
    {
        var icon = icons.Find(x=>x.window == window);
        icons.Remove(icon);
        Destroy(icon.gameObject);
    }

}

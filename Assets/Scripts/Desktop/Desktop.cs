using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Desktop : Singleton<Desktop>
{
    public List<WindowInfo> openWindowsOnStart = new();
    public List<WindowInfo> desktopIcons = new();

    [SerializeField] FileIconList desktopIconList;

    private void Start()
    {
        desktopIconList.Initialize(desktopIcons);
        foreach (WindowInfo info in openWindowsOnStart) 
            WindowManager.Instance.OpenWindow(info);
    }


}

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Desktop : Singleton<Desktop>
{
    public List<WindowInfo> desktopIcons = new();

    private void Start()
    {
        foreach (WindowInfo info in desktopIcons) 
        { 
            WindowManager.Instance.OpenWindow(info);
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    public GameObject textWindowPrefab;
    public GameObject imageWindowPrefab;
    public GameObject passwordWindowPrefab;
    public GameObject emailWindowPrefab;
    public GameObject discordWindowPrefab;
    public GameObject folderWindowPrefab;

    List<DesktopWindow> openWindows = new();

    [SerializeField] Transform windowsParent;
    
    public DesktopWindow OpenWindow(WindowInfo info)
    {
        if (openWindows.Any(x => x.WindowName == info.windowName))
        {
            openWindows.Find(x => x.WindowName == info.windowName).Open();
            return null;
        }

        var prefab = GetWindowPrefab(info);
        var go = Instantiate(prefab);
        go.transform.SetParent(windowsParent, false);
        var window = go.GetComponent<DesktopWindow>();

        window.Initialize(info);

        openWindows.Add(window);
        return window;
    }


    public void FocusWindow(DesktopWindow window)
    {
        window.transform.SetSiblingIndex(windowsParent.childCount);
    }

    public void CloseWindow(string windowName) 
    {
        var window = openWindows.Find(x => x.WindowName == windowName);
        openWindows.Remove(window);
        Destroy(window.gameObject);
    }


    private GameObject GetWindowPrefab(WindowInfo info)
    {
        if (info is TextWindowInfo)
            return textWindowPrefab;
        else if (info is ImageWindowInfo)
            return imageWindowPrefab;
        else if (info is PasswordWindowInfo)
            return passwordWindowPrefab;
        else if (info is EmailWindowInfo)
            return emailWindowPrefab;
        else if (info is FolderWindowInfo)
            return folderWindowPrefab;
        return null;
    }

}

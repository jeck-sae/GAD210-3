using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DesktopWindows/FolderWindow", fileName = "FolderWindow")]
public class FolderWindowInfo : WindowInfo
{
    public List<WindowInfo> files;
}

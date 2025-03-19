using UnityEngine;

public class FolderWindow : WindowBehaviour
{
    [SerializeField] FileIconList iconList;

    public override void Initialize(WindowInfo info)
    {
        FolderWindowInfo i = (FolderWindowInfo)info;
        iconList.Initialize(i.files);
    }
}

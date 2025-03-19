using System.Collections.Generic;
using UnityEngine;

public class FileIconList : MonoBehaviour
{
    [SerializeField] GameObject fileIconPrefab;
    [SerializeField] Transform fileIconsParent;

    public void Initialize(List<WindowInfo> icons)
    {
        foreach (var icon in icons) 
        { 
            SpawnIcon(icon);
        }


        void SpawnIcon(WindowInfo info)
        {
            var go = Instantiate(fileIconPrefab);
            go.transform.SetParent(fileIconsParent, false);
            var i = go.GetComponent<FileIcon>();
            i.Initialize(info);
        }
    }
}

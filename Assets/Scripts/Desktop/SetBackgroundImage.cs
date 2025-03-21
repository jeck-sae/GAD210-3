using System.Runtime.InteropServices;
using System;
using UnityEngine;
using UnityEngine.UI;
public class SetBackgroundImage : MonoBehaviour
{
    public RawImage RawImage;
    public Texture2D defaultBackground;

    private const UInt32 SPI_GETDESKWALLPAPER = 0x73;
    private const int MAX_PATH = 260;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(UInt32 uAction, int uParam, string lpvParam, int fuWinIni);

    void Start()
    {
        var path = GetCurrentDesktopWallpaperPath();
        if (string.IsNullOrEmpty(path))
        {
            SetDefaultBG();
            return;
        }

        var tex = LoadTextureFromPath(path);
        if (tex == null)
        {
            SetDefaultBG();
            return;
        }
        
        RawImage.texture = tex;
    }

    private void SetDefaultBG()
    {
        RawImage.texture = defaultBackground;
    }

    private Texture2D LoadTextureFromPath(string path)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(System.IO.File.ReadAllBytes(path));
        return texture;
    }

    private string GetCurrentDesktopWallpaperPath()
    {
        string currentWallpaper = new string('\0', MAX_PATH);
        SystemParametersInfo(SPI_GETDESKWALLPAPER, currentWallpaper.Length, currentWallpaper, 0);
        return currentWallpaper.Substring(0, currentWallpaper.IndexOf('\0'));
    }
}

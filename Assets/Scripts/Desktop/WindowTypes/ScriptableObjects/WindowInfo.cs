﻿using UnityEngine;

public abstract class WindowInfo : ScriptableObject
{
    public string windowName;
    public Sprite icon;
    public bool canClose = true;

    [Tooltip("Leave (0, 0) to keep the default window size")]
    public Vector2 windowSize;
}

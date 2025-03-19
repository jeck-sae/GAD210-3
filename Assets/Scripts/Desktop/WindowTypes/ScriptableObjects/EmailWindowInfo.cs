using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "DesktopWindows/EmailWindow", fileName = "EmailWindow")]
public class EmailWindowInfo : WindowInfo
{
    public List<EmailInfo> emails;

    [Serializable]
    public class EmailInfo
    {
        public string recipient;
        public string title;
        public string subject;
        public bool seen;
    }
}
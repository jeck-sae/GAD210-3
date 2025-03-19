using System;
using TMPro;
using UnityEngine;

public class EmailWindow : WindowBehaviour
{
    [SerializeField] TMP_Text selectedEmailTitle;
    [SerializeField] TMP_Text selectedEmailRecipient;
    [SerializeField] TMP_Text selectedEmailSubject;
    
    [SerializeField] GameObject emailPreviewPrefab;
    [SerializeField] Transform emailListParent;

    EmailWindowInfo info;

    public event Action<EmailWindowInfo.EmailInfo> SelectedEmail;

    public override void Initialize(WindowInfo info)
    {
        this.info = (EmailWindowInfo)info;

        selectedEmailTitle.text = "";
        selectedEmailRecipient.text = "";
        selectedEmailSubject.text = "";

        foreach (var email in this.info.emails)
        {
            var go = Instantiate(emailPreviewPrefab, emailListParent);
            go.GetComponent<EmailPreview>().Initialize(this, email);
        }
    }

    public void ShowEmail(EmailWindowInfo.EmailInfo emailInfo)
    {
        selectedEmailTitle.text = emailInfo.title;
        selectedEmailRecipient.text = emailInfo.recipient;
        selectedEmailSubject.text = emailInfo.subject;

        emailInfo.seen = true;
        SelectedEmail?.Invoke(emailInfo);
    }

    
}

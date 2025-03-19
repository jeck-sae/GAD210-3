using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPreview : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text subject;
    [SerializeField] Button button;
    [SerializeField] Image background;
    [SerializeField] Color seenColor;

    EmailWindow window;
    EmailWindowInfo.EmailInfo info;
    
    public void Initialize(EmailWindow window, EmailWindowInfo.EmailInfo info)
    {
        title.text = info.title;
        subject.text = info.subject;
        this.window = window;
        this.info = info;
        if (info.seen)
            background.color = seenColor;
        window.SelectedEmail += OnSelectedEmail;
    }

    public void Select()
    {
        background.color = seenColor;
        button.interactable = false;
        window.ShowEmail(info);
    }

    private void OnSelectedEmail(EmailWindowInfo.EmailInfo selectedInfo)
    {
        if (selectedInfo == info)
            return;

        button.interactable = true;
    }

    private void OnDestroy()
    {
        if(window)
            window.SelectedEmail -= OnSelectedEmail;
    }

}

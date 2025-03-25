using UnityEngine;

public class RollTheCredits : MonoBehaviour
{
    [SerializeField] GameObject[] objToSetActive;
    [SerializeField] AudioClip ghostSong;
    private bool active = false;
    private void OnTriggerEnter(Collider other)
    {
        if (active) return;
        if (other.CompareTag("Player"))
        {
            active = true;
            AudioManager.Instance.StopAllLoopSources(0.3f);
            AudioManager.Instance.PlaySound(ghostSong, 9f);
            float clipLength = ghostSong.length;
            Invoke("Show", clipLength);
        }
    }
    private void Show()
    {
        foreach (GameObject obj in objToSetActive)
        {
            if (obj != null)
                obj.SetActive(true);
        }
        Invoke("Delay", 3f);
    }
    private void Delay()
    {
        Fader.Instance.FadeForever(0.05f);
    }
}

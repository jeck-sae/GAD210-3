using UnityEngine;

[RequireComponent (typeof(Collider))]
public class ListenColider : MonoBehaviour
{
    [SerializeField] float timeToListen = 15f;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audioSource;
    private float timer = 0f;
    private bool playerIn = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           audioSource.Play();
           playerIn = true;
           Debug.Log("In colider");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
            timer = 0f;
            audioSource.volume = 0f;
        }
    }
    private void Update()
    {
        if (!playerIn)
        return;

        timer += Time.deltaTime;

        float volume = Mathf.Lerp(0f, 1f, timer / timeToListen);
        audioSource.volume = volume;

        if (timer > timeToListen)
        {
            anim.SetBool("Open", true);
            audioSource.Stop();
            audioSource.volume = 0f;
            Destroy(this);
        }
    }
}
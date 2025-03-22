using UnityEngine;

[RequireComponent (typeof(Collider))]
public class ListenColider : MonoBehaviour
{
    [SerializeField] float timeToListen = 15f;
    [SerializeField] Animator anim;
    private float timer = 0f;
    private bool playerIn = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
        }
    }
    private void Update()
    {
        if (!playerIn)
        return;

        timer += Time.deltaTime;
        if (timer > timeToListen)
        {
            anim.SetBool("Open", true);
        }
    }
}

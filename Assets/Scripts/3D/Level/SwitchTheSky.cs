using UnityEngine;

public class SwitchTheSky : MonoBehaviour
{
    [SerializeField] SkyBoxManager skyManager;
    [SerializeField] Material sky;
    [SerializeField] float rotationSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            skyManager.switchTheSky(sky, rotationSpeed);
        }
    }
}

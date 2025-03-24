using UnityEngine;

public class SupportLayersOfHell : MonoBehaviour
{
    [SerializeField] LayersOfHell layers;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            layers.CanBe();
        }
    }
}

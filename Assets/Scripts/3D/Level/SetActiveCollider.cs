using UnityEngine;

public class SetActiveCollider : MonoBehaviour
{
    [SerializeField] GameObject[] objToSetActive;
    [SerializeField] GameObject[] objToSetInactive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objToSetActive)
            {
                if (obj != null)
                obj.SetActive(true);
            }
            foreach (GameObject obj in objToSetInactive)
            {
                if (obj != null)
                obj.SetActive(false);
            }
        }
    }
}

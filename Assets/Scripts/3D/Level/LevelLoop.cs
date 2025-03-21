using UnityEngine;

public class LevelLoop : MonoBehaviour
{
    [SerializeField] Transform teleportTarget;
    [SerializeField] bool turnPlayer = false;
    private Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Calculate player's offset from the trigger
                offset = other.transform.position - transform.position;

                // Move player to new position while keeping offset
                other.transform.position = teleportTarget.position + offset;

                // Preserve velocity so movement remains smooth
                Vector3 newVelocity = rb.linearVelocity;

                if (turnPlayer)
                {
                    other.transform.rotation = Quaternion.Euler(0f, other.transform.eulerAngles.y + 180f, 0f);

                    // Rotate the velocity vector so movement continues
                    newVelocity = Quaternion.Euler(0, 180f, 0) * newVelocity;
                }

                // Apply the velocity
                rb.linearVelocity = newVelocity;
            }
        }
    }
}

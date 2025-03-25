using UnityEngine;

public class PlayerFallManager : MonoBehaviour
{
    [SerializeField] float fallThresholdY = -70f;
    [SerializeField] Transform respawnPosition;
    private Rigidbody rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (transform.position.y < fallThresholdY)
        {
            Fader.Instance.Fade(4f);
            Invoke("HandleFall", 4f);
        }
    }

    private void HandleFall()
    {
        rg.linearVelocity = Vector3.zero;
        transform.position = respawnPosition.position;
    }
}
using UnityEngine;

public class SightManager : MonoBehaviour
{
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private LayerMask targetLayer;

    private Transform lastLookedObject = null;

    private void Update()
    {
        CheckForLookAt();
    }

    private void CheckForLookAt()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, targetLayer))
        {
            SightObject sightObj = hit.transform.GetComponent<SightObject>();
            if (sightObj != null && hit.transform != lastLookedObject)
            {
                lastLookedObject = hit.transform;
                sightObj.OnLookAt(); // Trigger action
            }
        }
        else
        {
            lastLookedObject = null;
        }
    }
}
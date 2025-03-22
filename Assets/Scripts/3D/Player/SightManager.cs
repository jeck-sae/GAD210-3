using UnityEngine;

public class SightManager : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private LayerMask targetLayer;

    private SightObject lastsightObj = null;

    private void Update()
    {
        CheckForLookAt();
    }

    private void CheckForLookAt()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, targetLayer))
        {
            SightObject sightObj = hit.transform.GetComponent<SightObject>();

            if (sightObj != null)
            {
                if (sightObj != lastsightObj)
                {
                    lastsightObj?.OnLookAway(); // Trigger "stop looking" on the previous object
                    lastsightObj = sightObj;
                    sightObj.OnLookAt(); // Trigger "start looking"
                }
            }
        }
        else
        {
            if (lastsightObj != null)
            {
                lastsightObj.OnLookAway(); // Trigger "stop looking" when nothing is hit
                lastsightObj = null;
            }
        }
    }
}
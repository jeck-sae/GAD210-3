using UnityEngine;

public class SetActiveOnSight : SightObject
{
    [SerializeField] GameObject[] objToSetActive;
    [SerializeField] GameObject[] objToSetInactive;
    [SerializeField] bool setBack = false;

    public override void OnLookAt()
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
    public override void OnLookAway()
    {
        if (!setBack) return;

        foreach (GameObject obj in objToSetActive)
        {
            if (obj != null)
                obj.SetActive(false);
        }
        foreach (GameObject obj in objToSetInactive)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}

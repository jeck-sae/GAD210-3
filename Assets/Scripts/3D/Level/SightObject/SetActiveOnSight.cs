using UnityEngine;

public class SetActiveOnSight : SightObject
{
    [SerializeField] GameObject[] objToSetActive;
    [SerializeField] GameObject[] objToSetInactive;

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
}

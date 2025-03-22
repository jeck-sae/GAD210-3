using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] Transform[] allCheckPoints;
    private Transform currentCheckPoint;

    public void SetCheckPoint(Transform checkpoint)
    {
        currentCheckPoint = checkpoint;
    }
    public void TakePlayerToCheckPoint()
    {
        transform.position = currentCheckPoint.position;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            LazyWay();
        }
    }
    private void LazyWay()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        transform.position = allCheckPoints[0].position;
        if (Input.GetKeyDown(KeyCode.Alpha2))
        transform.position = allCheckPoints[1].position;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        transform.position = allCheckPoints[2].position;
        if (Input.GetKeyDown(KeyCode.Alpha4))
        transform.position = allCheckPoints[3].position;
        if (Input.GetKeyDown(KeyCode.Alpha5))
        transform.position = allCheckPoints[4].position;
        if (Input.GetKeyDown(KeyCode.Alpha6))
        transform.position = allCheckPoints[5].position;
        if (Input.GetKeyDown(KeyCode.Alpha7))
        transform.position = allCheckPoints[6].position;
        if (Input.GetKeyDown(KeyCode.Alpha8))
        transform.position = allCheckPoints[7].position;
        if (Input.GetKeyDown(KeyCode.Alpha9))
        transform.position = allCheckPoints[8].position;
    }

}
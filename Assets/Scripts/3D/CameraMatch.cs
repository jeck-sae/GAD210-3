using UnityEngine;

public class CameraMatch : MonoBehaviour
{
    [SerializeField] float ratio = 1;
    [SerializeField] Transform mainCam;

    void Update()
    {
        transform.rotation = mainCam.rotation;
        GetComponent<Camera>().fieldOfView = mainCam.GetComponent<Camera>().fieldOfView * ratio;
    }
}

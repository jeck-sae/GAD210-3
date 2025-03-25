using Unity.Cinemachine;
using UnityEngine;

public class ZoomModule : MonoBehaviour
{
    [Header("Zoom")]
    [SerializeField] PlayerControler controller;
    [SerializeField] CinemachineCamera playerCam;
    [SerializeField] bool enableZoom = true;
    [SerializeField] KeyCode zoomKey = KeyCode.Mouse1;
    [SerializeField] float zoomFOV = 30f;
    [SerializeField] float zoomStepTime = 5f;

    private float startFOV;
    private bool isZoomed = false;

    void Start()
    {
        startFOV = playerCam.Lens.FieldOfView;
        if (controller == null)
        controller = GetComponent<PlayerControler>();
    }

    void Update()
    {
        if (!enableZoom) return;

        if (controller.isSprinting == false)
        {
            if (Input.GetKeyDown(zoomKey))
            {
                isZoomed = true;
            }
            else if (Input.GetKeyUp(zoomKey))
            {
                isZoomed = false;
            }
        }

        if (isZoomed)
        {
            playerCam.Lens.FieldOfView = Mathf.Lerp(playerCam.Lens.FieldOfView, zoomFOV, zoomStepTime * Time.deltaTime);
        }
        else if (!isZoomed && controller.isSprinting == false)
        {
            playerCam.Lens.FieldOfView = Mathf.Lerp(playerCam.Lens.FieldOfView, startFOV, zoomStepTime * Time.deltaTime);
        }
    }
}

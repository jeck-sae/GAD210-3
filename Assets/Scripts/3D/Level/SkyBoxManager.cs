using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;

    private void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Get the current skybox material and apply the rotation
        RenderSettings.skybox.SetFloat("_Rotation", RenderSettings.skybox.GetFloat("_Rotation") + rotationAmount);
    }
}

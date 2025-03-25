using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Transform[] obj;
    [SerializeField] float x_Axis;
    [SerializeField] float y_Axis;
    [SerializeField] float z_Axis;

    private void Update()
    {
        // Create a rotation based on the assigned axis values
        Vector3 rotationVector = new Vector3(x_Axis, y_Axis, z_Axis) * Time.deltaTime;

        // Apply rotation to each object
        foreach (Transform tran in obj)
        {
            if (tran != null)
            {
                tran.Rotate(rotationVector, Space.Self); // Rotate in local space
            }
        }
    }
}
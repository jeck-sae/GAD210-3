using UnityEngine;

[RequireComponent (typeof(Collider))]
public class SightObject : MonoBehaviour
{
    public virtual void OnLookAt() { }
    public virtual void OnLookAway() { }
}
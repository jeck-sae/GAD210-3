using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] AudioClip ambient;
    void Start()
    {
        AudioManager.Instance.PlaySound(ambient, 0.5f, null, true);
    }
}
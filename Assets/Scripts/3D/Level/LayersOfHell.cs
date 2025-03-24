using TMPro;
using UnityEngine;

public class LayersOfHell : MonoBehaviour
{
    [SerializeField] int startLayer = 2;
    [SerializeField] TextMeshPro text;
    [SerializeField] Layer[] layers;
    private int currentLayer;
    public bool CanBeTriggered = false;

    void Start()
    {
        currentLayer = startLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CanBeTriggered) return;

        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in layers[currentLayer - startLayer].objToSetActive)
            {
                if (obj != null)
                obj.SetActive(false);
            }

            currentLayer++;
            text.text = currentLayer.ToString();

            foreach (GameObject obj in layers[currentLayer - startLayer].objToSetActive)
            {
                if (obj != null)
                obj.SetActive(true);
            }

            CanBeTriggered = false;
        }
    }
    public void CanBe()
    {
        CanBeTriggered = true;
    }
}
[System.Serializable]
public class Layer
{
    public GameObject[] objToSetActive;
}
using UnityEngine;
using UnityEngine.SceneManagement;



public class NextNewScene : MonoBehaviour
{

    public string nameOfNextScene;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {

            SceneManager.LoadScene(nameOfNextScene);

        }


    }

    


    




}

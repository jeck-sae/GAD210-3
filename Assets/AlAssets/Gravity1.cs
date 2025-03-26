using UnityEngine;

public class Gravity1 : MonoBehaviour
{

    public float gravity = -10f;

    private float normalGravity;




    void OnTriggerEnter2D(Collider2D other) 
    {


        if (other.CompareTag("Player"))
        {

            Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D>();

            if (rigidBody != null)
            {

                normalGravity = rigidBody.gravityScale;

                rigidBody.gravityScale = -Mathf.Abs(normalGravity);

            }


        }


    }

    

    void OnTriggerExit2D(Collider2D other) 
    {
        
        if(other.CompareTag("Player"))
        {

            Rigidbody2D rigidBody = other.GetComponent<Rigidbody2D>();

            if(rigidBody!= null)
            {

                
                rigidBody.gravityScale = Mathf.Abs(normalGravity);

            }


        }


    }


}

using UnityEngine;

public class MovCube : MonoBehaviour
{

    public float maxspeed= 10f;

    public float accel = 10f;
     
    public float decel = 10f;

    private Rigidbody2D cube;

    private Vector2 velociti;


    void Start()
    {

        cube = GetComponent<Rigidbody2D>();


    }

  

    void Update() 
    {

        float inputMove = Input.GetAxisRaw("Horizontal");


        if (inputMove!= 0)
        {

            velociti = Vector2.MoveTowards(velociti, new Vector2(inputMove * maxspeed, 0f), accel * Time.deltaTime);




        }

        else
        {

            velociti = Vector2.MoveTowards(velociti, Vector2.zero, decel * Time.deltaTime);



        }







    }


    void FixedUpdate()
    {

        cube.linearVelocity = velociti;

    }



}



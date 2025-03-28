using UnityEngine;

public class Open1 : MonoBehaviour
{

    public Transform movOb;

    public Vector2 direct = Vector2.right;

    public float speed = 1f;

    private bool movingAfterPlayer = false;

    public float distance = 3f;

    private Vector3 start;

    private Vector3 end; 


    void Start()
    {

        start = movOb.position;



        end = start + (Vector3)(direct.normalized * distance);



    }






    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {

            movingAfterPlayer = true;

        }

         

    }



    void Update()
    {
        
        if(movingAfterPlayer)
        {

            movOb.position = Vector3.MoveTowards(movOb.position, end, speed * Time.deltaTime);


            if (Vector3.Distance(movOb.position, end) < 0.1f)
            {

                movingAfterPlayer = false;

            }

        }


    }



}

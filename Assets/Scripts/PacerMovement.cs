using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PacerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform currentPoint;
    public GameObject pointA;
    public GameObject pointB;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //always declare ur rigidbody do not forget!!
        currentPoint = pointB.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            print("Going to point A");
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
            print("Going to point B");
        }
    }


}

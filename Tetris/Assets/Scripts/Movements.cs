using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);   //Store Touch Position Data
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position); //Fromula To Calculate Screen Boundary
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);   //Move Object Towards Touch Position
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed; 

            if (touch.phase == TouchPhase.Ended)    //
                rb.velocity = Vector2.zero;
        }
    }
}

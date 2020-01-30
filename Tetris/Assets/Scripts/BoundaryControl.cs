using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoundaryControl : MonoBehaviour
{
    public touch_Test touchtest;
    private bool canMove;
    private Quaternion rotation = new Quaternion(0f,0f,0f,90f);

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    private int tilted;
    private float a;

    private void Awake()
    {
        canMove = true;
        touchtest = FindObjectOfType<touch_Test>();
        rb = GetComponent<Rigidbody2D>();
        a = transform.rotation.eulerAngles.z;
        tilted = 1;
    }

    private void FixedUpdate()
    {
        
        if (canMove == true)
        {
            
            if (Input.GetKeyDown("t"))
            {
                
            }

            if (rb.velocity == new Vector2(0,0))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);   //Store Touch Position Data
                if (touch.phase == TouchPhase.Moved)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);     //Fromula To Calculate Screen Boundary
                    touchPosition.z = 0;
                    direction = (touchPosition - transform.position);   //Move Object Towards Touch Position
                    rb.velocity = new Vector2(direction.x , 0) * moveSpeed;
                }

                if (touch.phase == TouchPhase.Ended)    //To Stop object when touch is ended
                { 
                    //rb.velocity = Vector2.zero; 
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    rotate(rb.gameObject.name,90);
                }

            }
        }
    }
    private void rotate(string obj,float angel)
    {
        Debug.Log("Rotate 1");
        if (obj == "Z(Clone)")
        {
            switch (tilted)
            {
                case 1:
                    transform.Rotate(0f,0f,90f);
                    tilted = 2;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canMove == true)
        {
            if (collision.gameObject.CompareTag("LevelEnd"))
            {
                Debug.Log("At End");
                
                canMove = false;
                touchtest.Spawn(); 
                Destroy(this.gameObject);
                Destroy(this.gameObject.transform.parent.gameObject);

            }
            else if (collision.gameObject.CompareTag("BottomB") | collision.gameObject.CompareTag("Shapes"))
            {
                Debug.Log("Next");

                canMove = false;
                touchtest.Spawn();


            }
        }
    }
}

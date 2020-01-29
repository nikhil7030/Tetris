using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoundaryControl : MonoBehaviour
{
    public touch_Test touchtest;
    private bool canMove;
    private Quaternion rotation = new Quaternion(0f,0f,0f,90f);

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    private bool tilted;

    private void Awake()
    {
        canMove = true;
        touchtest = FindObjectOfType<touch_Test>();
        rb = GetComponent<Rigidbody2D>();
        
        tilted = false;
    }

    private void FixedUpdate()
    {
        
        if (canMove == true)
        {
            
            if (Input.GetKeyDown("t"))
            {
                Debug.Log("Rotate 1");
                //if (rb.gameObject.name.Equals("Z(Clone)"))
               // {
                    if (tilted == false)
                    {
                        Debug.Log("Rotate 2");
                        transform.Rotate(0f, 0f, 90f);
                        tilted = true;
                    }
                    else 
                    {
                        Debug.Log("Rotate 2");
                        transform.Rotate(0f, 0f, 0f);
                        tilted = false;
                    }
                    
               // }
            }

            if (rb.velocity == new Vector2(0,0))
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);   //Store Touch Position Data
                if (touch.phase == TouchPhase.Moved)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);     //Fromula To Calculate Screen Boundary
                    touchPosition.z = 0;
                    direction = (touchPosition - transform.position);   //Move Object Towards Touch Position
                    rb.velocity = new Vector2(direction.x , direction.y) * moveSpeed;
                }

                if (touch.phase == TouchPhase.Ended)    //To Stop object when touch is ended
                { 
                    //rb.velocity = Vector2.zero; 
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    Debug.Log("Rotate 1");
                    if (rb.gameObject.name.Equals("Z(Clone)"))
                    {
                        if (tilted == false)
                        {
                            Debug.Log("Rotate 2");
                            transform.Rotate(0f, 0f, 90f);
                            tilted = true;
                        }
                        else
                        {
                            Debug.Log("Rotate 2");
                            transform.Rotate(0f, 0f, 0f);
                            tilted = false;
                        }

                    }
                }

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

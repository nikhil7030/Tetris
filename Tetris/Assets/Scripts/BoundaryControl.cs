using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControl : MonoBehaviour
{
    public touch_Test touchtest;
    private bool canMove;
    private Vector3 rotation = new Vector3(0f,0f,-90);

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    private void Awake()
    {
        canMove = true;
        touchtest = FindObjectOfType<touch_Test>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
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
                    rb.velocity = new Vector2(0, direction.y) * moveSpeed;
                }
                if (touch.phase == TouchPhase.Ended)    //
                    rb.velocity = Vector2.zero;
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

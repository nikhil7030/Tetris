using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControl : MonoBehaviour
{
    public touch_Test touchtest;
    private bool canMove;
    private void Awake()
    {
        canMove = true;
        touchtest = FindObjectOfType<touch_Test>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove == true)
        {
            if (collision.gameObject.CompareTag("LevelEnd"))
            {
                Debug.Log("At End");
                
                //canMove = false;
                //touchtest.Spawn(); 
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

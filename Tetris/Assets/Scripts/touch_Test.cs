using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touch_Test : MonoBehaviour
{
    public GameObject[] Shapes;
    public Transform[] spawnPoint;
    [SerializeField]  private float speed;
    private void Start()
    {
        StartCoroutine(Spawn());
    }


    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            Instantiate(Shapes[Random.Range(0, 3)]);
        }

        foreach (Touch touch in Input.touches)
        {
            Debug.Log(touch.position);
        }

        if (Input.touchCount > 0)
        {
           // Instantiate(Shapes[Random.Range(0, 3)],spawnLoc);

            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                //tShape.transform.position = Vector3.Lerp(tShape.transform.position, touchPosition, Time.deltaTime);
            }
        }
    }
     
    IEnumerator Spawn()
    {
        
        for ( ; ; )
        {
            Instantiate(Shapes[Random.Range(0,7)],spawnPoint[Random.Range(0,6)]);
            Debug.Log("Tik Tok.....");
            yield return new WaitForSeconds(speed);
            
        }
    }

}

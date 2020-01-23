using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touch_Test : MonoBehaviour
{
    public GameObject[] Shapes;
    public Transform spawnPoint;
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private GameObject obj;
    [SerializeField] private float speed = 3f;
    private void Awake()
    {
        Spawn();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    


    void Update()
    {
        

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
     
    public void Spawn()
    {

            Instantiate(Shapes[Random.Range(0, 6)], spawnPoint);
            Debug.Log("Tik Tok.....");
            /*
            if (obj.transform.position.x > -23 | obj.transform.position.x > 1)
            {
                DestroyImmediate(obj);
            }
            else if (obj.transform.position.y < 5 | obj.transform.position.y > 18.52)
            {
                DestroyImmediate(obj);
            }*/
            //yield return new WaitForSeconds(speed); 
        
    }

}

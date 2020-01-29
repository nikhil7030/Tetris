using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class reset : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(0);   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    Scene scene;
     void Awake()
    {
         scene = SceneManager.GetActiveScene();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        //SceneManager.Load
    }
}

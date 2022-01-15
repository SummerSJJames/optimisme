using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    int scene;
     void Awake()
    {
     
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.LoadGameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            FindObjectOfType<AudioManager>().Mute("InGame");
            FindObjectOfType<AudioManager>().Play("Theme");
        }
        else
        {
            FindObjectOfType<AudioManager>().Mute("Theme");
            FindObjectOfType<AudioManager>().Play("InGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

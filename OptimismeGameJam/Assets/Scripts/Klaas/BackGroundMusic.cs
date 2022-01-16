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
            FindObjectOfType<AudioManager>().Mute("EndAnim");
            FindObjectOfType<AudioManager>().Mute("GameOver");
            FindObjectOfType<AudioManager>().Play("Theme");
        }
        else if (SceneManager.GetActiveScene().name == "EndingAnimation")
        {
            FindObjectOfType<AudioManager>().Mute("InGame");
            FindObjectOfType<AudioManager>().Mute("Theme");
            FindObjectOfType<AudioManager>().Mute("GameOver");
            FindObjectOfType<AudioManager>().Play("EndAnim");
        }
        else if (SceneManager.GetActiveScene().name == "GameOver")
        {
            FindObjectOfType<AudioManager>().Mute("InGame");
            FindObjectOfType<AudioManager>().Mute("Theme");
            FindObjectOfType<AudioManager>().Mute("EndAnim");
            FindObjectOfType<AudioManager>().Play("GameOver");
        }
        else
        {
            FindObjectOfType<AudioManager>().Mute("EndAnim");
            FindObjectOfType<AudioManager>().Mute("Theme");
            FindObjectOfType<AudioManager>().Mute("GameOver");
            FindObjectOfType<AudioManager>().Play("InGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public AudioMixer audioMixer;

    private void Start()
    {
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");
     
        optionsMenu.SetActive(false);
    }

   
    public void StartGame()
    {
        SceneManager.LoadScene("Summer");
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Game Started...");
    }

    public void OptionsOn()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Options Showing...");
    }
    public void OptionsOff()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Options Hidden");
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
        Debug.Log("Quit...");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Volume Changed...");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("FullScreen Changed...");
        FindObjectOfType<AudioManager>().Play("Click");
    }

}

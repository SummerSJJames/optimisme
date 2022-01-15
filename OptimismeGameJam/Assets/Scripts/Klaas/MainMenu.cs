using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject levelSelection;

    public AudioMixer audioMixer;
    public AudioMixer themeMixer;

    private void Start()
    {
        mainMenu = GameObject.Find("MainMenu");
        optionsMenu = GameObject.Find("OptionsMenu");
        levelSelection = GameObject.Find("LevelSelection");

        levelSelection.SetActive(false);
        optionsMenu.SetActive(false);
    }


    public void StartGame()
    {
        // StartCoroutine(LevelLoader.LoadLevel(1));
        SceneManager.LoadScene("Tutorial");
        FindObjectOfType<AudioManager>().Play("Click");
        FindObjectOfType<AudioManager>().Mute("Theme");
        FindObjectOfType<AudioManager>().Play("InGame");
        Debug.Log("Game Started...");
    }

    public void PlayLevel()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        FindObjectOfType<AudioManager>().Mute("Theme");
        FindObjectOfType<AudioManager>().Mute("EndAnim");
        FindObjectOfType<AudioManager>().Play("InGame");
    }
    public void PlayCredits()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        FindObjectOfType<AudioManager>().Mute("Theme");
        FindObjectOfType<AudioManager>().Mute("InGame");
        FindObjectOfType<AudioManager>().Play("EndAnim");
    }

    public void OptionsOn()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Options Showing...");
    }

    public void LevelSelectionOff()
    {
        levelSelection.SetActive(false);
        mainMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void LevelSelectionOn()
    {
        levelSelection.SetActive(true);
        mainMenu.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");
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

    public void SetThemeVolume(float themeVolume)
    {
        themeMixer.SetFloat("ThemeVolume", themeVolume);
        // FindObjectOfType<AudioManager>().Play("Click");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        // FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Volume Changed...");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("FullScreen Changed...");
        FindObjectOfType<AudioManager>().Play("Click");
    }

}

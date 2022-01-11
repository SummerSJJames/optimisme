using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Image fadeToBlack;
    [SerializeField] Button Quit;
    [SerializeField] Button Restart;
    [SerializeField] Button MainMenu;

    [SerializeField] AudioSource catScreech;

    [SerializeField] float increment;

    public static bool gameOver;
    public bool resetting;

    private void Start()
    {
        gameOver = false;
        resetting = false;
        fadeToBlack.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameOver)
        {
            Debug.Log("yes");
        }
        else if (resetting)
        {
            //if (fadeToBlack.color.a > 0)
            //    fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, fadeToBlack.color.a - (increment * Time.deltaTime / 100));

            //if (fadeToBlack.color.a >= 1)
            //    resetting = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Summer");
    }

    public void ReturnMainMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

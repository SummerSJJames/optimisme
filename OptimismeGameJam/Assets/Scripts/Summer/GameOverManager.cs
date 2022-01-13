using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Button Quit;
    [SerializeField] Button Restart;
    [SerializeField] Button MainMenu;

    [SerializeField] float increment;

    public static bool gameOver;
    public bool resetting;

    static int currentLevel;

    private void Start()
    {
        gameOver = false;
        resetting = false;
        //fadeToBlack.gameObject.SetActive(false);

        //if (SceneManager.GetActiveScene().ToString() != "GamerOver")
        //    currentLevel = SceneManager.GetActiveScene().buildIndex;
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
        LevelManager.LoadLastLevel();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Klaas");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

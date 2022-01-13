using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 2;

    public static int lastLevel;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadLastLevel()
    {
        SceneManager.LoadScene(lastLevel);
    }
    public static void LoadLevel(int currentL)
    {
        currentLevel = currentL;
        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadGameOver()
    {
        lastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}

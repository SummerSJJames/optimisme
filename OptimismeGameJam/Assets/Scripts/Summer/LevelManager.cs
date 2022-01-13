using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 2;

    public static int lastLevel;

    static List<Button> levelButtons;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }

    public static void LoadLastLevel()
    {
        SceneManager.LoadScene(lastLevel);
    }
    public static void LoadLevel(int currentL)
    {
        currentLevel = currentL;
        levelButtons[currentLevel - 2].gameObject.SetActive(true);
        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadNextLevel()
    {
        currentLevel++;
        levelButtons[currentLevel - 2].gameObject.SetActive(true);
        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadGameOver()
    {
        lastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 2;

    public static int lastLevel;

    public List<Button> levelButtons;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        //currentLevel = SceneManager.GetActiveScene().buildIndex;

        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public static void LoadLastLevel()
    {
        SceneManager.LoadScene(lastLevel);
    }
    public void LoadLevel(int currentL)
    {
        currentLevel = currentL;

        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadNextLevel()
    {
        currentLevel++;
        //levelButtons[currentLevel - 2].gameObject.SetActive(true);

        if (currentLevel > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", currentLevel);
        }

        SceneManager.LoadScene(currentLevel);
    }
    public static void LoadGameOver()
    {
        lastLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }
}

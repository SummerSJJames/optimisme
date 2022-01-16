using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    [SerializeField] GameObject holder;

    public static bool menuIsActive;

    private void Start()
    {
        holder.SetActive(false);
        menuIsActive = false;
    }

    private void Update()
    {
        Debug.Log(menuIsActive);
        if (!Dialogue.dialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !menuIsActive)
            {
                menuIsActive = true;
                holder.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && menuIsActive)
            {
                menuIsActive = false;
                holder.SetActive(false);
            }
        }        
    }

    public void CloseMenu()
    {
        menuIsActive = false;
        holder.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

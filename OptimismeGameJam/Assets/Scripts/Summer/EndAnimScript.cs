using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PlayingAnim());
    }

    IEnumerator PlayingAnim()
    {

        yield return new WaitForSeconds(11f);
        SceneManager.LoadScene("MainMenu");
    }
}

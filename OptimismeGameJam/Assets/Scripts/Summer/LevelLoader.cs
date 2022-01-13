using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] GameObject blackScreen;
    static Animator transition;
    [SerializeField] static float transitionTime = 1f;

    [SerializeField] TMP_Text numberPetText;

    public static int catsPet = 0;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //    instance = this;
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        transition = blackScreen.GetComponent<Animator>();
        catsPet = 0;
    }

    private void Update()
    {
        numberPetText.text = catsPet.ToString();
    }

    public static IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}

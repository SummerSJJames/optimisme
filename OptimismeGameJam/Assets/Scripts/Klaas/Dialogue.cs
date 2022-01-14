using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea(1, 3)]
    public string[] lines;

    public int[] whoSpeaks;

    public float textSpeed;

    private int index;
    public static bool dialogueActive;

    [SerializeField] GameObject player;
    [SerializeField] GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        //player.SetActive(false);
        //robot.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        dialogueActive = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {       
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueActive = false;
            gameObject.SetActive(false);
        }

        if (whoSpeaks[index] == 0)
        {
            robot.SetActive(false);
            player.SetActive(true);
        }
        else
        {
            player.SetActive(false);
            robot.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] lines;
    public float speedText;
    public Text dialogueText;
    public int index;

    private void Start()
    {
        dialogueText.text = string.Empty;
        gameObject.SetActive(false);
    }
    public void  startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            print(c);
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText); 
        }
    }

    private void nextLines()
    {
        if(index <= lines.Length)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void skipTextClick()
    {
        if(dialogueText.text == lines[index])
        {
            nextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
    public void endDialogue()
    {
        dialogueText.text = string.Empty;
    }
}

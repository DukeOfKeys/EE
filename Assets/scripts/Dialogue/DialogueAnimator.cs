using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueAnimator : MonoBehaviour
{
    private bool check;
    public GameObject StartDialogueText;
    [SerializeField] public GameObject DialogueBox;
    public string[] lines;
    public float speedText;
    public Text dialogueText;
    public int index;
    private void StartDialogue()
    {
        DialogueBox.SetActive(true);
        endDialogue();
        startDialogue();
    }



    /// <summary>
    public void startDialogue()
    {
        dialogueText.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    private void nextLines()
    {
        if (index <= lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            DialogueBox.SetActive(false);
        }
    }

    public void skipTextClick()
    {
        if ((lines.Length - 1) <= index) {
 
                DialogueBox.SetActive(false);
            StartDialogueText.SetActive(false);
        }
        if (dialogueText.text == lines[index])
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
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & check == true)
        {
            StartDialogueText.SetActive(false);
            StartDialogue();
            check = false;
        } else if (Input.GetKeyDown(KeyCode.Space) == true){
            print("Максим Ебаная чурка!!!!");
            skipTextClick();
        }
    }
    private void Start()
    {
        StartDialogueText.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            check = true;
            StartDialogueText.SetActive(true);                                                                                             
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "hero")
        {
            DialogueBox.SetActive(false);
            StartDialogueText.SetActive(false);
        }
    }   
}

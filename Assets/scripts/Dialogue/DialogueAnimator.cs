using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    private int check;
    private void StartDialogue()
    {
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueSystem>().endDialogue();
        FindObjectOfType<DialogueSystem>().startDialogue();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & check == 1 )
        {
            StartDialogueText.SetActive(false);
            StartDialogue();
            check = 0;
        }
    }
    private void Start()
    {
        StartDialogueText.SetActive(false);
    }
    public GameObject StartDialogueText;
    public GameObject DialogueBox;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            check = 1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    private bool check;
    private void StartDialogue()
    {
        DialogueBox.SetActive(true);
        FindObjectOfType<DialogueSystem>().endDialogue();
        FindObjectOfType<DialogueSystem>().startDialogue();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & check == true )
        {
            StartDialogueText.SetActive(false);
            StartDialogue();
            check = false;
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

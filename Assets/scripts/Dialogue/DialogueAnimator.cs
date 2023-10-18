using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", false);
        dm.EndDialogue();
    }
}

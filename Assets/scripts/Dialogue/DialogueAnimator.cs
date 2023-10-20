using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public string Animation; 
       
    public Animator startAnim;
    public DialogueManager dm;
    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.name == "hero")
        startAnim.SetBool(Animation, true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "hero")
            startAnim.SetBool(Animation, false);
        dm.EndDialogue();
    }
}

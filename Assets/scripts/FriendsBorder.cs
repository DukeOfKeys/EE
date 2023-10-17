using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if (other.tag == "Hero")
        {
            Friends.bff = "Hero";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("Trigger Exited");
        Friends.bff = null;
    }
}

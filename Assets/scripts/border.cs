using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if (other.tag == "Hero")
        {
            Enemy.aim = "Hero";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("Trigger Exited");
            Enemy.aim = null;
    }
}

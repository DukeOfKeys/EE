using UnityEngine;
using System;
using System.Diagnostics;


public class Saves : Hero
{

    public void Save()
    {
        PlayerPrefs.SetFloat("Save [X]", x);
        PlayerPrefs.SetFloat("Save [Y]", y);

        PlayerPrefs.Save();
        print("ей");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save [X]") && PlayerPrefs.HasKey("Save [Y]"))
        {
            x = PlayerPrefs.GetFloat("Save [X]");
            y = PlayerPrefs.GetFloat("Save [Y]");
        }

        playerPos.transform.position = new Vector2(x, y);    
    }
}
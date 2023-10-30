using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject LoadButton;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitbutton()
    {
        Application.Quit();
    }
    public void OnNewGameButton()
    {
        if (File.Exists(Application.persistentDataPath + "/DataSaves.dat"))
        {
            File.Delete(Application.persistentDataPath + "/DataSaves.dat");
        }
    }

    private void Update()
    {
        if (File.Exists(Application.persistentDataPath + "/DataSaves.dat")) LoadButton.SetActive(true);
        else LoadButton.SetActive(false);
    }
}
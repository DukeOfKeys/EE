using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton (){
    SceneManager.LoadScene(1);
    }
    public void OnQuitbutton(){
Application.Quit();
    }
}

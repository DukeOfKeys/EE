using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    public GameObject PopUpMenue;
    public bool GameIsPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) Resume();
            else Pause();
        }

    }
    [SerializeField] public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PopUpMenue.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        PopUpMenue.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class realchangelevel : MonoBehaviour
{
    public int sceneBuildIndex;
    public void chageLevel() {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}

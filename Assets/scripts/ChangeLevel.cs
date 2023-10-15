using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    public int sceneBuildIndex;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        print ("Trigger Entered");
        if(other.tag == "Hero"){
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex,LoadSceneMode.Single);
        }
    }
}

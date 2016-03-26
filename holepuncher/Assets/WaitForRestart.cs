using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaitForRestart : MonoBehaviour {

    // wait for the user to press any key to restart the level. 
	void Update() {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

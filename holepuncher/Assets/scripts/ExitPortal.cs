using UnityEngine;
using System.Collections;

public class ExitPortal : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D obj) {
        /*
        Checks if colliding object is tagged "Player" and if so, performs all the actions associated with success!
        */
        if (obj.gameObject.tag == "Player") {
            // placeholder. will make actual win event later. 
            Debug.Log("Player has completed the level");
        }
    }
}

using UnityEngine;
using System.Collections;

public class ExitPortal : MonoBehaviour {
    private GameObject gm; //gm stands for game manager. 
    void Start() {
        gm = GameObject.FindWithTag("GameManager");
        if (gm == null) {
            Debug.Log("couldn't find game manager object.");
        }
    }
    void OnTriggerEnter2D(Collider2D obj) {
        /*
        Checks if colliding object is tagged "Player" and if so, performs all the actions associated with success!
        */
        if (obj.gameObject.tag == "Player") {
            // placeholder. will make actual win event later. 
            //Debug.Log("Player has completed the level");
            // We want to keep the player graphically in the same position, but cease all movement and physics.
            // we can do this by disabling the control and movement scripts and removing the rigidbody. 
            RifterControl rc = obj.gameObject.GetComponent<RifterControl>();
            rc.enabled = false;
            RifterControlInterface rci = obj.gameObject.GetComponent<RifterControlInterface>();
            rci.enabled = false;
			Destroy(GameObject.Find("blackHole_parent"));	//Alex's note: I added this.
			Destroy(GameObject.Find("whiteHole_parent"));	//Alex's note: I added this.
            //Destroy(obj.gameObject.GetComponent<Rigidbody2D>()); //remove the rigid body component from the game object. 
            //contact the game manager to do all the other game won stuff.
            gm.SendMessage("gameWon");
        }
    }
}

using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour {

    private GameObject gm; //gm stands for game manager. 
    public void Start() {
        gm = GameObject.FindWithTag("GameManager");
        if (gm == null) {
            Debug.Log("couldn't find game manager object.");
        }

    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Fatal")) {
            //player has been killed.
            // We want to keep the player graphically in the same position, but cease all movement and physics.
            // we can do this by disabling the control and movement scripts and removing the rigidbody. 
            RifterControl rc = gameObject.GetComponent<RifterControl>();
            rc.enabled = false;
            RifterControlInterface rci = gameObject.GetComponent<RifterControlInterface>();
            rci.enabled = false;

            Destroy(gameObject.GetComponent<Rigidbody2D>()); //remove the rigid body component from the game object. 
            //contact the game manager to do all the other death stuff. 
            gm.SendMessage("gameOver");


        }
    }

}

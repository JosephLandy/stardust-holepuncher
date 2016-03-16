using UnityEngine;
using System.Collections;

public class DynParent : MonoBehaviour {
    /**
    This script performs dynamic parenting of colliding objects. It essentially fixes the problem of the character standing on
    objects that move out from under them.
    The idea is to take colliding objects and make them a child of the moving platform. On collision exit, make them a child of world again. 
    */
    //public void OnCollisionEnter2D(Collision2D col) {
    //    //have to make sure colliding objecct is tagged
    //    if (col.gameObject.GetComponent<Rigidbody2D>() != null) {
    //        Debug.Log("rigid body 2d found");
    //        col.gameObject.transform.parent = gameObject.transform;
    //    }
    //}


    public GameObject p;

    public void OnTriggerEnter2D(Collider2D other) { 
        //Ok, this isn't working

        if (other.CompareTag("Player")) {
            other.gameObject.transform.parent = gameObject.transform;

        }
    }

    public void OnCollisionStay2D(Collision2D col) {
        //since on trigger/collider enter didn't work, and in fact, parenting doesn't seem to be working at all, 
        //lets try using on collision stay and not bothering with the parenting thing. We will just get change in position, and
        //update the characters position with it every frame he remains on the moving object. this may very well cause problems however.
        //since this is designed to handle a swinging object. Might be able to fix that by tracking the change in position of some point. 
        //if we do this, it might cause difficulty with the player actually moving on the surface. 
        if (col.gameObject.CompareTag("Player")) {

        }
    }
}

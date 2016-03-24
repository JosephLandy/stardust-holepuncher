using UnityEngine;
using System.Collections;

public class DynamicCameraZone : MonoBehaviour {
	private fakeDynamicCamera cameraScript;

	public Vector2 centerPosition;		//use this to determine where the camera will go when the player enters this area
	public float scaleFactor;			//use this to determine how far the camera zooms out

	void Start (){
		cameraScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<fakeDynamicCamera>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			cameraScript.SetMode(1, centerPosition, scaleFactor);
        }
    }

	void OnTriggerExit2D(Collider2D col) { 
		if (col.gameObject.tag == "Player")
			cameraScript.SetMode(2, centerPosition, scaleFactor);
	}
}

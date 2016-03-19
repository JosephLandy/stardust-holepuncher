using UnityEngine;
using System.Collections;

public class DynamicCameraZone1 : MonoBehaviour {
	public GameObject cameraBLAH;

	void Start (){
		cameraBLAH = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			cameraBLAH.SendMessage ("SetMode", 1);
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player")
			cameraBLAH.SendMessage ("SetMode", 2);
	}
}

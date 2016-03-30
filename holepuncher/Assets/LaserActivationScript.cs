using UnityEngine;
using System.Collections;

public class LaserActivationScript : MonoBehaviour {
	private RightMovingLaserScript[] laserScript;
	//private GameObject[] laser;

	void Start () {
		//laserScript =
		laserScript = new RightMovingLaserScript[6];
		for (int x = 0; x < 6; x++) {
			char c = (char)(x + 48);
			string name = "mlaser" + c;
			laserScript [x] = GameObject.Find (name).GetComponent<RightMovingLaserScript> ();
		}
	}										//^fix this^

	void OnTriggerEnter2D(Collider2D col){
		for (int x = 0; x < 3; x++) {
			if (col.gameObject.tag == "Player" && laserScript [x].identity < 3) {
				laserScript [x].active = true;			
			}
		}
	}

}

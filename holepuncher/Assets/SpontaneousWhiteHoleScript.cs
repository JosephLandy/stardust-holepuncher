using UnityEngine;
using System.Collections;

public class SpontaneousWhiteHoleScript : MonoBehaviour {
	private Vector3 spawnPoint;
	private WhiteHoleMaker whiteHoleScript;
	private GameObject whiteHole;

	public void Start (){
		whiteHoleScript = GameObject.Find ("whiteHole_parent").GetComponent<WhiteHoleMaker>();
	}

	public void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject.tag == "Player") {
			spawnPoint = obj.GetComponent<Transform> ().position;
			whiteHoleScript.makeWhiteHole (spawnPoint);
			whiteHole = GameObject.Find ("Whitehole(Clone)");
			whiteHole.GetComponent<PointEffector2D> ().forceMagnitude = 1000;
			Object.Destroy(whiteHole.GetComponentInChildren<SpriteRenderer>());
		}
	}
}

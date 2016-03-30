using UnityEngine;
using System.Collections;

public class SpontaneousWhiteHoleScript : MonoBehaviour {
	private Vector3 spawnPoint;
	public GameObject holePrefab;

	public void Start (){
	}

	public void OnTriggerEnter2D(Collider2D obj) {
		if (obj.gameObject.tag == "Player") {
			spawnPoint = obj.GetComponent<Transform> ().position;
			GameObject hole = (GameObject)Instantiate(holePrefab, spawnPoint, Quaternion.identity);
		}
	}
}

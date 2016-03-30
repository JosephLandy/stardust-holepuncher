using UnityEngine;
using System.Collections;

public class NoGravityScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
	}
}

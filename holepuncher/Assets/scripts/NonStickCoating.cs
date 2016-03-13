using UnityEngine;
using System.Collections;

public class NonStickCoating : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col) {
        Rigidbody2D incphys = col.gameObject.GetComponent<Rigidbody2D>();
        incphys.velocity = new Vector2(0f, incphys.velocity.y);
    }

}

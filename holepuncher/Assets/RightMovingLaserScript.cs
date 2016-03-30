using UnityEngine;
using System.Collections;

public class RightMovingLaserScript : MonoBehaviour {
	public float moveSpeed = 0.03f;
	private Vector3 pos;
	private bool heightShifted = false;
	[HideInInspector] public int identity;
	public bool active;
	public GameObject laserpair;

	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		string lasername = name;
		identity = lasername [6] - 48;	//"mlaserX"
		//if (identity < 3) active = true;
		//else active = false;
		//active = false;
	}

	/*void heightShift(float newHeight){
		pos.y = Mathf.SmoothDamp (transform.position.y, newHeight, ref velocity.y, 0.5f);
		heightShifted = true;
	}*/


	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			pos = transform.position;
			if (identity < 3) {
				if (!heightShifted && pos.x >= 35.9)
					heightShifted = true;
				else if (heightShifted && transform.position.y != -1.46f)
					pos.y = Mathf.SmoothDamp (transform.position.y, -1.46f, ref velocity.y, 0.5f);
				transform.position = new Vector3 (pos.x + moveSpeed, pos.y, pos.z);
			}
			if (identity >= 3) {
				if (!heightShifted && pos.x >= 57)
					heightShifted = true;
				else if (heightShifted && transform.position.y != -11.3f)
					pos.y = Mathf.SmoothDamp (transform.position.y, -11.3f, ref velocity.y, 0.5f);
				transform.position = new Vector3 (laserpair.transform.position.x, pos.y, pos.z);
			}

		}
		if (!active && identity >= 3) {
			if (transform.position.x < laserpair.transform.position.x) {
				pos.x = laserpair.transform.position.x;
				active = true;
				transform.position = new Vector3 (laserpair.transform.position.x, transform.position.y, transform.position.z);
			}
		}
	}
}
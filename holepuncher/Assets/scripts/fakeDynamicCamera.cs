using UnityEngine;
using System.Collections;

public class fakeDynamicCamera : MonoBehaviour {
	private Vector2 velocity;

	//public float smoothTimeX;
	//public float smoothTimeY;
	public float smoothTime;

	public GameObject player;
	public Camera camera;

	private int mode;
	private float posX;
	private float posY;
	private float originalSize;
	private float dumbfloatidk;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		camera = this.GetComponent<Camera>();
		mode = 0;
		originalSize = camera.orthographicSize;
	}

	void SetMode (int mode){ //this specifically works with DynamicCameraZone1.cs
		this.mode = mode;
		//print(mode);
	}

	void FixedUpdate(){
		if (mode == 1) {
			posX = Mathf.SmoothDamp (transform.position.x, 32.61f, ref velocity.x, smoothTime * 50);		//change the time to change how quickly the camera transitions
			posY = Mathf.SmoothDamp (transform.position.y, -5.3f, ref velocity.y, smoothTime * 50);			//32.61f and -5.3f are the center of the puzzle area, don't change. 
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, 7.0f, ref dumbfloatidk, smoothTime * 50);
			transform.position = new Vector3 (posX, posY, transform.position.z);
		} else if (mode == 2) {
			posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTime*20);
			posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTime*20);
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, originalSize, ref dumbfloatidk, smoothTime*20);
			transform.position = new Vector3 (posX, posY, transform.position.z);
			if ((int) transform.position.x == (int) player.transform.position.x && (int) transform.position.y == (int) player.transform.position.y) mode = 0;
		}

		else {		//normal camera movement
			posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
			posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, originalSize, ref dumbfloatidk, smoothTime);
			transform.position = new Vector3 (posX, posY, transform.position.z);
		}
	}
}

//position: 32.5, -5.2
//scale: 28,14 -> 14,7 -> scale up the camera to 7.
//actual scale: 28,11.79
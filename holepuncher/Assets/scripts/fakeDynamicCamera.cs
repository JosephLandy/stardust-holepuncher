﻿using UnityEngine;
using System.Collections;

public class fakeDynamicCamera : MonoBehaviour {
	private Vector2 velocity;

	//public float smoothTimeX;
	//public float smoothTimeY;
	public float smoothTime;

	private GameObject player;

	private Vector2 playerPos;
	private Vector2 targetPos;
	private float targetScale;
	private Camera camera;

	private int mode;
	private float posX;
	private float posY;
	private float originalScale;
	private float dumbfloatidk;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");//.transform.position;
		playerPos = player.transform.position;
		camera = this.GetComponent<Camera>();
		mode = 0;
		originalScale = camera.orthographicSize;
	}

	public void SetMode (int mode, Vector2 targetPos, float targetScale){ //this specifically works with DynamicCameraZone.cs
		this.mode = mode;
		this.targetPos = new Vector2 (targetPos.x, targetPos.y);	//For Zone 1, (32.5f, -5.2f)
		this.targetScale = targetScale;
	}

	void FixedUpdate(){
		playerPos = player.transform.position;
		//playerPos.y += 2;
		if (mode == 1) {
			posX = Mathf.SmoothDamp (transform.position.x, targetPos.x, ref velocity.x, smoothTime * 50);		//change the time to change how quickly the camera transitions
			posY = Mathf.SmoothDamp (transform.position.y, targetPos.y, ref velocity.y, smoothTime * 50);			//32.61f and -5.3f are the center of the puzzle area, don't change. 
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, targetScale, ref dumbfloatidk, smoothTime * 50);
			transform.position = new Vector3 (posX, posY, transform.position.z);
		} else if (mode == 3) {
			posX = Mathf.SmoothDamp (transform.position.x, playerPos.x + targetPos.x, ref velocity.x, smoothTime);	
			posY = Mathf.SmoothDamp (transform.position.y, playerPos.y + targetPos.y, ref velocity.y, smoothTime);	
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, targetScale, ref dumbfloatidk, smoothTime * 50);
			transform.position = new Vector3 (posX, posY, transform.position.z);
		} else if (mode == 2) {
			posX = Mathf.SmoothDamp (transform.position.x, playerPos.x, ref velocity.x, smoothTime * 20);
			posY = Mathf.SmoothDamp (transform.position.y, playerPos.y, ref velocity.y, smoothTime * 20);
			camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, originalScale, ref dumbfloatidk, smoothTime * 20);
			transform.position = new Vector3 (posX, posY, transform.position.z);
			//print (playerPos.x);
			if (Mathf.Abs (transform.position.x - playerPos.x) < 0.1 && Mathf.Abs (transform.position.y - playerPos.y) < 0.1)
				mode = 0;
		} else {		//normal camera movement
			posX = Mathf.SmoothDamp (transform.position.x, playerPos.x, ref velocity.x, smoothTime);
			posY = Mathf.SmoothDamp (transform.position.y, playerPos.y, ref velocity.y, smoothTime);
			//if (mode == 3) camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, targetScale, ref dumbfloatidk, smoothTime*20);
			 camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, originalScale, ref dumbfloatidk, smoothTime);
			transform.position = new Vector3 (posX, posY, transform.position.z);
		}
	}
}

//position: 32.5, -5.2
//scale: 28,14 -> 14,7 -> scale up the camera to 7.
//actual scale: 28,11.79
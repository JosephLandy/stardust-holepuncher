﻿using UnityEngine;
using System.Collections;

public class BlackHoleMaker : MonoBehaviour {
    public GameObject holePrefab;

    void Update() {
        //closeHoles is mapped to the c button. 
        if (Input.GetButtonDown("closeHoles")) {
            closeAllHoles();
        }

        if (Input.GetMouseButtonDown(0)) {
            createHole();
            
        }
    }

    public void createHole() {
        Vector3 mouse = Input.mousePosition; //this is in screen space. have to add a z component and transform it into world space.
                                             //unfortuneately this doesn't work in perspective view. Not really sure if it's something fixable. 
        mouse.z = 0f;
        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(mouse);
        worldCoord.z = 0;
        makeBlackHole(worldCoord);
    }

    public void makeBlackHole(Vector3 position) {
        GameObject hole = (GameObject) Instantiate(holePrefab, position, Quaternion.identity);
        //Instantiate returns an Object (unity class, not java base class). Must cast into a game object. 
		closeAllHoles(); //here's where we need to kill the child 
        hole.transform.parent = gameObject.transform; //parent the hole to the hole manager game object

    }

    public void closeAllHoles() {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}

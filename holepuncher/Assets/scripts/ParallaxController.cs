using UnityEngine;
using System.Collections.Generic;
using System;
public class ParallaxController : MonoBehaviour {

    public Transform player; //transform associated with the player game object. 



    private Vector3 prevPlayerPosition;

    public float paralaxFactor = 0.6f;

    public GameObject[] paraLayers;

    //note: parallax factors have to be fairly close to 1 to have a significant effect. 
    public float[] paralaxFactors;

    void Start() {
        /*the parallax object is not parented to the player, this following bit makes sure the 
        background is centred on the player character
        
        I actually think this won't matter and should be removed.*/ 

        prevPlayerPosition = player.position;
        Vector3 pos = transform.position;
        pos.x = player.position.x;
        pos.y = player.position.y;
        transform.position = pos;

        printChildren(transform);
    }



    void LateUpdate() {

        Vector3 offset = transform.position + calcOffset(player.position);

        int nLayers = paraLayers.Length;
        Vector3 newLayerPosition;
        for (int i = 0; i < nLayers; i++) {


        }
        //finally, update the prevPlayerPosition 
        prevPlayerPosition = player.position;
    }
    
    private void printChildren(Transform T) {
        foreach (Transform child in T) {
            Debug.Log(child.ToString());

        }
    }

    private Vector3 calcOffset (Vector3 newPosition) {
        //want the background to move in the opposite direction from the player, so multiply by negative of parallax factor. 
        Vector3 output = (newPosition - prevPlayerPosition) * paralaxFactor;
        return output;
    }

}

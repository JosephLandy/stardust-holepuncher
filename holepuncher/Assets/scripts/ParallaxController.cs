using UnityEngine;
using System.Collections.Generic;
using System;
public class ParallaxController : MonoBehaviour {

    /* This script only covers movement of backgrounds. It has no effect on ordering, occlusion, z coordinate, or any other properties of backgrounds. 
        I reccommend dragging the background prefab into the scene rather than constructing it from scratch. 
        populate the parallax layers array with the individual layers of the background (note that each is a single game object, but can contain multiple sprites as children)
        then populate the parallax factors array with a factor for each layer. 

        It might be worth only using this script for the distant background, and not immediate background elements. 

        You also have to set drag the player character to the player property in the editor.
    */
    public Transform player; //transform associated with the player game object. 
    private Vector3 prevPlayerPosition; //records the previous position, in order to calculate delta position.

    public Transform[] parallaxLayers;
    //note: parallax factors have to be fairly close to 1 to have a significant effect. 
    public float[] paralaxFactors;

    void LateUpdate() {

        Vector3 playerDeltaP = player.position - prevPlayerPosition;
        int nLayers = parallaxLayers.Length;
        Vector3 newLayerPosition;

        for (int i = 0; i < nLayers; i++) {
            newLayerPosition = parallaxLayers[i].position + (playerDeltaP * paralaxFactors[i]);
            parallaxLayers[i].position = newLayerPosition;
        }
        //finally, update the prevPlayerPosition 
        prevPlayerPosition = player.position;
    }
}

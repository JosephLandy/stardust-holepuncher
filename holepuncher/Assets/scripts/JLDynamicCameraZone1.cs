using UnityEngine;
using System.Collections;

public class JLDynamicCameraZone1 : MonoBehaviour {
    public GameObject cam;
	void Start (){
		//cameraBLAH = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
            //cameraBLAH.SendMessage ("SetMode", 1
            //Camera cam = col.gameObject.transform.GetComponentInChildren<Camera>(); //jl - find the main camera child.
            //Debug.Log(cam);
            //DynCam dc = cam.GetComponent<DynCam>();
            //dc.start_zoomOut();
            //cameraBLAH.SendMessage("start_zoomOut");
            //cam.gameObject.SendMessage("start_zoomOut");
            //GameObject cam = col.gameObject.GetComponentInChildren<Camera>().gameObject;
            //Debug.Log(cam);
            Debug.Log("calling start zoom out");
            cam.SendMessage("start_zoomOut");
        }


    }
	void OnTriggerExit2D(Collider2D col) { //have to zoom back in here. 
		//if (col.gameObject.tag == "Player")
			//cameraBLAH.SendMessage ("SetMode", 2);
	}
}

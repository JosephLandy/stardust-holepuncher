using UnityEngine;
using System.Collections;

public class DynCam : MonoBehaviour {
    public bool finished;

    private Animator anim;
    private int zoomOut_trigger_h; //hash value of zoomOut trigger 

    private Camera cam;
    void Start() {
        anim = GetComponent<Animator>();
        cam = GetComponent<Camera>();
    }
    public void setFinished() {
        finished = true;
        anim.SetBool("Done", false);
    }

    public void start_zoomOut() {
        //call the trigger. 
        Debug.Log("calling start zoomOut function");
        anim.SetTrigger(TriggerHashes.zoomOut);
    }

    public void set_zoomOut_done() {
        finished = true;
        anim.SetTrigger(TriggerHashes.zoomOut_complete);
        float endSize = cam.orthographicSize;


    }

    private class TriggerHashes {
        public static int zoomOut = Animator.StringToHash("zoomOut");
        public static int zoomOut_complete = Animator.StringToHash("zoomOut_complete");
    }
}

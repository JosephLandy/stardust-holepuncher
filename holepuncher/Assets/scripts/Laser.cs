using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    private LineRenderer visual;

	void Start () {
        visual = gameObject.GetComponent<LineRenderer>();
    }

	void Update () {
        // note: position 0 will always be at (0,0,0) relative to the object.
        RaycastHit2D hit = Physics2D.Raycast(transform.TransformPoint(Vector3.zero), -transform.up);
        visual.SetPosition(1, transform.InverseTransformPoint(hit.point));
    }
}

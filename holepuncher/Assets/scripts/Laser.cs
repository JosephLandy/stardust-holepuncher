using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    private LineRenderer visual;
    public Transform sparks; // only need the transform of the sparks particle system. Don't need to access it as either a GameObject or ParticleSystem

	void Start () {
        visual = gameObject.GetComponent<LineRenderer>();
    }

	void Update () {
        // note: position 0 will always be at (0,0,0) relative to the object.
		// alex note: To get it to ignore the holes layer, I'm making it collide with everything but the holes layer
		RaycastHit2D hit = Physics2D.Raycast(transform.TransformPoint(Vector3.zero), -transform.up, Mathf.Infinity, LayerMask.NameToLayer("holes"));
        visual.SetPosition(1, transform.InverseTransformPoint(hit.point));

        // the sparks component should always be located at the point of contact, and be oriented along the normal of the surface hit by the laser. 
        sparks.transform.position = hit.point;
        // hit.normal returns a vector2. need it as a vector3
        Vector3 normal = new Vector3(hit.normal.x, hit.normal.y);
        sparks.transform.right = normal;

        if (hit.collider.CompareTag("Player") && Application.isPlaying) { //have to make sure that we are not calling this while editing, using isPlaying.
            // if the object hit by the laser is the Player. Kill the player.
            hit.collider.gameObject.SendMessage("killme");

        }
    }
}

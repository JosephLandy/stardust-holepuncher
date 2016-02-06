using UnityEngine;
using System.Collections;

public class BlackHoleMaker : MonoBehaviour {

    public GameObject holePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            createHole();
        }
    }

    public void createHole() {
        Vector3 mouse = Input.mousePosition; //this is in screen space. have to add a z component and translate it into world space. 
        mouse.z = 0f;

        Vector3 worldCoord = Camera.main.ScreenToWorldPoint(mouse);
        worldCoord.z = 0;
        makeBlackHole(worldCoord);

    }

    public void makeBlackHole(Vector3 position) {
        GameObject hole =(GameObject) Instantiate(holePrefab, position, Quaternion.identity);
        //Instantiate returns an Object (unity class, not java base class). Must cast into a game object. 

        hole.transform.parent = gameObject.transform; //parent the hole to the hole manager game object

    }
}

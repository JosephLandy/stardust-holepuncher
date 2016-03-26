using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {
    private Text text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	
	}

    //activate the text component to show the text.
    public void showMeDeath() {
        if (gameObject.name == "gameOver_text") {
            text.enabled = true;
        }
    }

    public void showMeWin() {
        if (gameObject.name == "gameWon_text") {
            text.enabled = true;
        }
    }
}

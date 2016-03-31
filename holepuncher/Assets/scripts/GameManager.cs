using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private Animator anim;
    private int deathID;
    private int winID;
	private Scene scene;

	// Use this for initialization
    public void Start() {
        anim = GetComponent<Animator>();
        deathID = Animator.StringToHash("death"); // hashed id value for the trigger named death. 
        // Trigger Named Death would be a good name for a very shitty band. 
        // In other news, I think I actually hate this new keyboard I got even more than I hated my old one. 
        // and I really, really HATED that keyboard. 
		scene = SceneManager.GetActiveScene ();
        winID = Animator.StringToHash("win");
    }

    public void gameOver() {
        //Debug.Log("game over message recieved by game manager.");
        anim.SetTrigger(deathID);

    }

    public void gameWon() {
        //Debug.Log("game won message received by game manager.");
        anim.SetTrigger(winID);
		if(scene.name == "final_scene") SceneManager.LoadScene ("scene2");
		//if(scene.name = "scene2") SceneManager.LoadScene ("final_scene");
    }

    public void enableGameOverRestart() {
        // Enable the script which waits for user input before restarting
        WaitForRestart wfr = GetComponent<WaitForRestart>();
        wfr.enabled = true;
        // display the game over text
        BroadcastMessage("showMeDeath");

    }
    
    public void enableGameWinRestart() {
        WaitForRestart wfr = GetComponent<WaitForRestart>();
        wfr.enabled = true;
        BroadcastMessage("showMeWin");
    }

	public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

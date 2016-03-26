using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class RifterControl_gm : MonoBehaviour
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can WALK in the x axis.
	[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
	[SerializeField] private LayerMask m_WhatIsGround;              // A mask determining what is ground to the character. 0 should be "Default"
	[Range(1, 10)] [SerializeField] private int m_FakeFriction = 2;

	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Transform m_CeilingCheck;   // A position marking where to check for ceilings
	const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_rb2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private int m_signFlip = 1; 			// Set to either 1 or -1

	private void Awake()
	{
		// Setting up references.
		m_GroundCheck = transform.Find("GroundCheck");
		m_CeilingCheck = transform.Find("CeilingCheck");
		m_WhatIsGround = 1;		//LayerMask 1 is "Default"; if you wanna change it while testing, sure, but it should be default by default.
		m_Anim = GetComponent<Animator>();
		m_rb2D = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}
		m_Anim.SetBool("Ground", m_Grounded);

		// Set the vertical animation
		m_Anim.SetFloat("vSpeed", m_rb2D.velocity.y);
	}

	//How I do it: calculate the speed, add it, and then make sure the result is acceptable.
	public void Move(float hSpeed, bool jump)
	{
		float absSpeed = Mathf.Abs (hSpeed);

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		m_Anim.SetFloat("Speed", absSpeed);

		//Movement calculations ------
        //JL note - here is where we might be able to check a boolean to not add speed if at a wall. 
		if (hSpeed < 0 && m_rb2D.velocity.x > 0 || hSpeed > 0 && m_rb2D.velocity.x < 0)		//If the player is trying to move in the opposite direction than they are actually moving
			m_rb2D.velocity += new Vector2 (hSpeed * m_MaxSpeed, 0f);							//add the calculated speed.
		else if (Mathf.Abs (m_rb2D.velocity.x) < m_MaxSpeed) {								//If the player is not at the speed limit but wants to be
			m_rb2D.velocity += new Vector2 (hSpeed * m_MaxSpeed, 0f);							//add the calculated speed.
			if (Mathf.Abs (m_rb2D.velocity.x) > m_MaxSpeed)									//If the player is now above the speed limit (and wants to be)
				m_rb2D.velocity = new Vector2 (m_MaxSpeed * m_signFlip, m_rb2D.velocity.y); 	//set their speed to the speed limit.
		}
		//What if the speed is pushed above our decided speed limit by an external force? Well, we don't do anything.
		//We don't need to do anything, and if we do, we might mess up the otherwise natural motion.

		//print (hSpeed);
		//print (m_rb2D.velocity);


		// If the input is moving the player right and the player is facing left, flip the player
		if (hSpeed > 0 && !m_FacingRight) Flip();
		// If the input is moving the player left and the player is facing right, flip the player
		else if (hSpeed < 0 && m_FacingRight) Flip();

		// If the player should jump...
		if (m_Grounded && jump && m_Anim.GetBool("Ground"))
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Anim.SetBool("Ground", false);
			m_rb2D.AddForce(new Vector2(0f, m_JumpForce));
		}


		if (m_Grounded && absSpeed == 0f) applyFriction();
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		m_signFlip = -m_signFlip;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void applyFriction() {
		//since this function is only called from within an if statement saying (m_Grounded && absSpeed == 0f), we can assume the player is on the ground and not trying to move
		Vector2 tempVect = new Vector2(m_rb2D.velocity.x, m_rb2D.velocity.y);
		tempVect.x /= m_FakeFriction;
		if (Mathf.Abs (tempVect.x) < 0.5)
			tempVect.x = 0;
		m_rb2D.velocity = tempVect;
	}

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Fatal")) {
            killme();
        }
        
    }



    //Joseph here: I'm adding a method, to kill the player and reload the scene. It can be called by other objects, or within this class.
    public void killme() {
        // call when player needs to be killed. 
        Debug.Log("kill me called, reloading scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
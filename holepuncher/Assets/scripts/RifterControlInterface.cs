using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class RifterControlInterface : MonoBehaviour
{

	private RifterControl m_Character;
	private bool m_Jump;
	//private bool m_Left;
	//private bool m_Right;


	private void Awake()
	{
		m_Character = GetComponent<RifterControl>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	}


	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		//bool left = CrossPlatformInputManager.GetButtonDown ("Negative Button") || CrossPlatformInputManager.GetButtonDown ("Alt Negative Button");
		//bool right = CrossPlatformInputManager.GetButtonDown ("Positive Button") || CrossPlatformInputManager.GetButtonDown ("Alt Positive Button");
		//if (!left && !right) h = 0;
		//print (h);
		// Pass all parameters to the character control script.
		m_Character.Move(h, m_Jump);
		m_Jump = false;
	}
}


using System.Collections;
using UnityEngine;

public class PauseInputHandler : MonoBehaviour 
{
	//Reference to the pauseLogic script
	private PauseLogic logic;
	private void Start()
	{
		//Create the reference
		logic = GetComponent<PauseLogic> ();
	}
	private void Update () 
	{
		//Pause the game when the escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			logic.switchPauseState ();
		}
	}
}
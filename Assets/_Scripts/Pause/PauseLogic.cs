//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;

public class PauseLogic : MonoBehaviour 
{
	//Reference to the ui script
	private PauseUI ui;
	private ShootInput shootInput;
	private DoDamage damageInput;
	private Movement playerMovement;

	//Boolean to check if we are already paused
	private bool paused;
	public bool isPaused{get{return paused;}}

	private void Start()
	{
		//Create reference
		setReferences();
		//Set startvalue to the boolean
		paused = false;
	}

	private void setReferences()
	{
		ui = GetComponent<PauseUI> ();
		shootInput = GetComponent<ShootInput> ();
		damageInput = GetComponent<DoDamage> ();
		playerMovement = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Movement>();
	}

	public void switchPauseState()
	{
		//if already paused, continue
		if (paused)
		{
			paused = false;
			continueGame ();
			return;
		}

		//If not paused, pause
		if (!paused)
		{
			paused = true;
			pauseGame ();
			return;
		}
	}

	private void pauseGame()
	{
		//enable the UI
		ui.enablePausePanel ();

		//Stop the movement
		Time.timeScale = 0;

		//Stop the scripts
		startScripts (false);
	}

	private void continueGame()
	{
		//Hide all the panels
		ui.hideAll ();

		//Enable the movement
		Time.timeScale = 1;

		//Start all the scripts
		startScripts (true);
	}

	private void startScripts(bool value)
	{
		//Stop scripts that do not use the time
		shootInput.enabled = value;
		damageInput.enabled = value;
		playerMovement.enabled = value;
	}
}
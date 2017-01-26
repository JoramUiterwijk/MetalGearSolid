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
	private PlayerController playerMovement;

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
		playerMovement = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerController>();
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
		stopScripts ();
	}

	private void continueGame()
	{
		//Hide all the panels
		ui.hideAll ();

		//Enable the movement
		Time.timeScale = 1;

		//Start all the scripts
		startScripts ();
	}

	private void stopScripts()
	{
		//Stop scripts that do not use the time
		shootInput.enabled = false;
		damageInput.enabled = false;
		playerMovement.enabled = false;
	}

	private void startScripts()
	{
		//Start scripts that do not use the time
		shootInput.enabled = true;
		damageInput.enabled = true;
		playerMovement.enabled = true;
	}
}
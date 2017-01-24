//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneUI : MonoBehaviour 
{
	//Reference to the laoding script
	private LoadSceneVisible loadGame{get;set;}

	//Reference to the text that will tell the progress
	//you can set this object in the inspector
	[Tooltip("Put the textObject that will show the percentage here.")]
	[SerializeField] private Text loadPercentage;

	//Reference to the LoadingPanel
	[Tooltip("Put the panel for your loading in here.")]
	[SerializeField] private GameObject loadingPanel;

	private void Start()
	{
		//Create reference to the loading script
		loadGame = GetComponent<LoadSceneVisible>();
	}
		
	public void showLoadingScreen()
	{
		loadingPanel.SetActive (true);
	}

	public void UpdateUI()
	{
		//Get the Progress value
		float percentage = loadGame.GetPercentage;

		//Set the progress text
		loadPercentage.text = "Loading: "+percentage + "%";
	}
}

//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneVisible : MonoBehaviour 
{
	//a variable to store the progress
	private float percentage{get;set;}
	//Reference to the UIScript
	private LoadSceneUI loadUI{get;set;}

	private void Start()
	{
		//Create the reference to the script
		loadUI = GetComponent<LoadSceneUI>();
	}

	//This is the function you have to call to load
	public void LoadScene(int sceneIndex)
	{
		//Set a start value to the percentage
		percentage = 0;
		//Show the loading scene
		loadUI.showLoadingScreen();
		//start the loading
		StartCoroutine(Load(sceneIndex));
	}

	IEnumerator Load(int i)
	{
		//Create a variable that loads the scene
		//In this case it will load scene one, you can set this in the buildsettings, which is an array of scenes
		AsyncOperation async = SceneManager.LoadSceneAsync(i);

		//while loading is not done...
		while (!async.isDone)
		{
			//the progress will be between 0 and 0.9 so we will calculate it to be between 0 and 100
			percentage = Mathf.Floor ((async.progress * 100) / 0.9f);
			//Update the UI in the UIscript
			loadUI.UpdateUI ();
			//yield return something (Because the IEnumerator requires that)
			yield return null;
		}
	}

	public float GetPercentage
	{
		get
		{
			//Make sure the UIscript can access the progress value
			return percentage;
		}
	}
}

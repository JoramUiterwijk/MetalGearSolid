//From www.freetimedev.com
//Written by Dani van der Werf
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneInvisible : MonoBehaviour 
{
	//This is the function you have to call to load
	public void LoadScene(int sceneIndex)
	{
		//start the loading
		StartCoroutine(Load(sceneIndex));
	}

	IEnumerator Load(int i)
	{
		//Create a variable that loads the scene
		//In this case it will load scene one, you can set this in the buildsettings, which is an array of scenes
		SceneManager.LoadSceneAsync(i);
		yield return null;
	}
}

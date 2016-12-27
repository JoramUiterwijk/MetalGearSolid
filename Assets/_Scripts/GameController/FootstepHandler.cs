using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepHandler : MonoBehaviour 
{
	private AudioHandler audio;
	[SerializeField]private AudioClip step;
	[SerializeField]private AudioClip metal;

	[SerializeField]private GameObject riddle;
	//[SerializeField]private GameObject splash;

	private void Start()
	{
		audio = GetComponent<AudioHandler> ();
	}
	public void standardStep()
	{
		audio.playAudio (step, false);
	}

	public void metalStep()
	{
		//audio.playAudio(metal,false);
	}

	public void waterStep(Vector3 position)
	{
		audio.playAudio (step, false);
		GameObject theRiddle = Instantiate (riddle, position, Quaternion.Euler(90,0,0)) as GameObject;
		//GameObject theSplash = Instantiate (splash, position, Quaternion.identity) as GameObject;
	}
}

using System.Collections;
using UnityEngine;

public class AudioHandler : MonoBehaviour 
{
	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource> ();
	}

	public void playAudio(AudioClip newClip,bool loop)
	{
		source.clip = newClip;
		source.loop = loop;
		source.Play ();
	}
}

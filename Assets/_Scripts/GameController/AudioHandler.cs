using System.Collections;
using UnityEngine;

public class AudioHandler : MonoBehaviour 
{
	private AudioSource source;
	private Value values;

	private void Start()
	{
		source = GetComponent<AudioSource> ();
		values = GetComponent<Value> ();
		source.volume = values.Volume;
	}

	public void playAudio(AudioClip newClip,bool loop)
	{
		source.clip = newClip;
		source.loop = loop;
		source.Play ();
	}
}

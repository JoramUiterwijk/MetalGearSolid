using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ambianceVolume : MonoBehaviour 
{
	private AudioSource source;
	private Value values;

	private void Start()
	{
		source = GetComponent<AudioSource> ();
		values = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Value> ();
		source.volume = values.Volume;
	}
}

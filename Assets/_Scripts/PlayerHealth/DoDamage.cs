using System.Collections;
using UnityEngine;

public class DoDamage : MonoBehaviour 
{
	private PlayerHealth health;

	private void Start()
	{
		health = GetComponent<PlayerHealth> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			health.doDamage (10);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : MonoBehaviour 
{
	private Clips clips;
	private void Start()
	{
		clips = GetComponent<Clips> ();	
	}

	public void shoot()
	{
		clips.removeBullet (1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour 
{
	private ShootLogic logic;
	private Clips clips;
	private void Start()
	{
		logic = GetComponent<ShootLogic> ();
		clips = GetComponent<Clips> ();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown (0)&&!clips.isReloading&&clips.curCapasity>0)
		{
			logic.shoot ();
		}
	}
}

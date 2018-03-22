using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour 
{
	[SerializeField]private Transform player;
	[SerializeField]private float[] offsets;
	[SerializeField]private bool trackRotation;

	private void LateUpdate()
	{
		transform.position = new Vector3 (player.position.x+offsets[0],offsets[1],player.position.z+offsets[2]);
		if (trackRotation)
		{
			transform.localRotation = Quaternion.Euler(0,player.rotation.eulerAngles.y,0);
		}
	}
}

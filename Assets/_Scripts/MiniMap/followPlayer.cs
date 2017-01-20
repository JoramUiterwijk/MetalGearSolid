using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour 
{
	[SerializeField]private Transform player;
	[SerializeField]private float y;

	private void LateUpdate()
	{
		transform.position = new Vector3 (player.position.x,y,player.position.z);
	}
}

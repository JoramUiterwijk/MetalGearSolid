using System.Collections;
using UnityEngine;

public class CheckFloor : MonoBehaviour 
{
	private RaycastHit hit;
	private FootstepHandler handler;
	[SerializeField]private GameObject[] feet;

	private void Start()
	{
		handler = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<FootstepHandler> ();
	}

	public void checkGround(int footIndex)
	{
		if(Physics.Raycast(feet[footIndex].transform.position,-transform.up,out hit,10f))
		{
			if (hit.collider.CompareTag (Tags.ground))
			{
				handler.playStepSound("normal");
			}

			if (hit.collider.CompareTag (Tags.stairs))
			{
				handler.playStepSound("metal");
			}

			if(hit.collider.CompareTag (Tags.water))
			{
				handler.waterStep (feet[footIndex].transform.position);
			}
		}
	}
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class HandleAnimations : MonoBehaviour 
{
	private Rigidbody rigid;
	private Animator anim;
	private void Start()
	{
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	public void checkMovementInput(float zInput, float xInput)
	{
		float velocity = (Mathf.Abs (zInput)/2) + (Mathf.Abs(xInput)/2);
		anim.SetFloat ("velocity", velocity);
	}
}

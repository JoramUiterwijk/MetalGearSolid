using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimations : MonoBehaviour 
{
	private Rigidbody rigid;
	private Animator anim;
	private Vector3 prevPos = Vector3.zero;

	private void Start()
	{
		setReferences ();
	}

	private void setReferences()
	{
		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	private void Update()
	{
		Vector3 vel = transform.position - prevPos;
		prevPos = transform.position;
		float val = vel.z + vel.x;
		anim.SetFloat ("velocity",Mathf.Abs(val));
		print (Mathf.Abs(val));
	}
}

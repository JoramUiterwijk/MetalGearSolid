using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour 
{
	private float speed;
	private Rigidbody rigid;
	private Vector3 movement;
	private Vector3 prevMovement;
	private HandleAnimations anim;

	private void Start()
	{
		speed = 15f;

		movement = Vector3.zero;
		prevMovement = Vector3.zero;

		rigid = GetComponent<Rigidbody> ();
		anim = GetComponent<HandleAnimations> ();
	}

	private void Update()
	{
		var x = Input.GetAxisRaw ("Horizontal");
		var z = Input.GetAxisRaw ("Vertical");
		anim.checkMovementInput (z,x);

		movement = new Vector3 (x,0,z);

		if (!(x == 0 && z == 0))
		{
			prevMovement = movement;
		}
	}

	private void FixedUpdate()
	{
		Vector3 velocity = movement.normalized * speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.position + velocity);

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(prevMovement), 0.2F);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private float x;
    private float z;
    private Rigidbody rigidBody;
    private float speed = 11;
    private float dash = 2.0f;

    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector3 previousMovement = Vector3.zero;
	private Animator anim;


    public Vector3 eulerAngleVelocity;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
    }

    private void Movement()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(previousMovement), 0.3F);

		transform.Translate(movement * speed * Time.deltaTime, Space.World);

		if (!(movement.x == 0 && movement.z == 0))
		{
			previousMovement = movement;
			anim.SetFloat ("velocity", 10);
		} 
		else
		{
			anim.SetFloat ("velocity", 0);
		}
        
    }

    void FixedUpdate()
    {
		Movement();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private float x;
    private float z;
    private Rigidbody rigidBody;
    private float speed = 10;
    private float dash = 2.0f;

    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector3 previousMovement = Vector3.zero;


    public Vector3 eulerAngleVelocity;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
		
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(previousMovement), 0.10F);

        transform.Translate(movement * 5 * Time.deltaTime, Space.World);

        if(!(movement.x == 0 && movement.z == 0))
        {
            previousMovement = movement;
        }
        
    }

    void FixedUpdate()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rigidBody.rotation = Quaternion.Euler(rigidBody.rotation.eulerAngles + new Vector3(0f, 2 * x, 0f));
        rigidBody.MovePosition(rigidBody.position + velocity);

		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}
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

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        movement = transform.forward.normalized * z;
    }

    void FixedUpdate()
    {
        Vector3 velocity = movement * speed * Time.fixedDeltaTime;
        rigidBody.rotation = Quaternion.Euler(rigidBody.rotation.eulerAngles + new Vector3(0f, 2 * x, 0f));
        rigidBody.MovePosition(rigidBody.position + velocity);
        //rigidBody.AddForce(Physics.gravity * rigidBody.mass);
    }
}
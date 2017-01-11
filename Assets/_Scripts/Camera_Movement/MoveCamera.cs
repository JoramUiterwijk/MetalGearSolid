using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float mass = 10;

    private Vector3 position;
    private Vector3 velocity;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float rotateStep;

    private void Start()
    {
        position = this.gameObject.transform.position;
    }

	public void newPosition (Transform newTrans)
    {    
        targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
        rotateStep = (targetRotation.eulerAngles.x - this.gameObject.transform.localRotation.eulerAngles.x)/mass;
    }

	void Update ()
    {
        if(Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.5)
        smoothMove();
        smoothRotate();
    }

    private void smoothMove()
    {
        //smooth naar de target bewegen. moet nog aan werken!!!
        Vector3 desiredStep = targetPosition - gameObject.transform.position;

        desiredStep.Normalize();

        Vector3 desiredVelocity = desiredStep * maxSpeed;

        Vector3 steeringForce = desiredVelocity - velocity;

        velocity = velocity + steeringForce / mass;

        position += velocity * Time.deltaTime;
        transform.position = position;

        //this.gameObject.transform.position = targetPosition;      
    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = targetRotation;
    }
}

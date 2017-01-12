using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10;

    private float slowDownSpeed;

    private Vector3 targetPosition;

    private Quaternion targetRotation;

    [SerializeField]
    private float rotateSpeed = 10;

    private bool newPositionReached = true;
    private bool newRotationReached = true;

    public void newPosition (Transform newTrans)
    {    
        targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
        newPositionReached = false;
        newRotationReached = false;
        slowDownSpeed = maxSpeed;
    }

	void Update ()
    {
        if(Vector3.Distance(targetPosition, this.gameObject.transform.position) > 2f && !newPositionReached)
            smoothMove();      
        else if (Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.2 && !newPositionReached)
            smothSlowdown();
        else if(Vector3.Distance(targetPosition, this.gameObject.transform.position) <= 0.3)
            newPositionReached = true;

        if (gameObject.transform.localRotation != targetRotation && !newRotationReached)
            smoothRotate();
        else
            newRotationReached = true;
    }

    private void smoothMove()
    {
        //smooth naar de target bewegen. moet nog aan werken!!!
        Vector3 desiredStep = targetPosition - gameObject.transform.position;

        desiredStep.Normalize();

        desiredStep = desiredStep * maxSpeed;

        transform.position += desiredStep * Time.deltaTime;
    
    }
    
    private void smothSlowdown()
    {
        if(slowDownSpeed > 0.1f)
        {
            slowDownSpeed *= 0.9f;
        }

        Vector3 desiredStep = targetPosition - gameObject.transform.position;

        desiredStep.Normalize();

        desiredStep = desiredStep * slowDownSpeed;

        transform.position += desiredStep * Time.deltaTime;
    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed); ;
    }
}

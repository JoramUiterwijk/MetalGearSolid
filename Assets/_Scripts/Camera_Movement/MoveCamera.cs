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

	public void newPosition (Transform newTrans)
    {    
        targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
        newPositionReached = false;
        slowDownSpeed =
    }

	void Update ()
    {
        if(Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.3 && !newPositionReached)
            smoothMove();
        else
            newPositionReached = true;

        if (Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.3 && Vector3.Distance(targetPosition, this.gameObject.transform.position) < 0.8 && !newPositionReached)
            smothSlowdown();
       
        if(!newPositionReached)
        smoothRotate();
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

    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed); ;
    }
}

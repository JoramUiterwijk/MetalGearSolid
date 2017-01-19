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

    private CameraRotate cameraRotate;

    private void Start()
    {
        cameraRotate = gameObject.GetComponent<CameraRotate>();
    }

    public void newPosition (Transform newTrans)
    {    
        targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
        newPositionReached = false;
        newRotationReached = false;
        slowDownSpeed = maxSpeed;
        cameraRotate.desiredRotation(newTrans, rotateSpeed);
    }

	void Update ()
    {
        if (!newPositionReached)
        {
            if (Vector3.Distance(targetPosition, this.gameObject.transform.position) > 2f )
                smoothMove();
            else if (Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.3)
                smothSlowdown();
            else if (Vector3.Distance(targetPosition, this.gameObject.transform.position) <= 0.3)
                newPositionReached = true;
        }        
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
}

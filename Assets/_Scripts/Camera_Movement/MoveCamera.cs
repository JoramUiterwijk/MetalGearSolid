using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = .1f;

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
        cameraRotate.desiredRotation(newTrans, rotateSpeed);
    }

	void Update ()
    {
        if (!newPositionReached)
        {
            if (Vector3.Distance(targetPosition, this.gameObject.transform.position) > 0.1f )
                smoothMove();
            else
                newPositionReached = true;
        }        
    }

    private void smoothMove()
    {
        transform.position = Vector3.Slerp(gameObject.transform.position, targetPosition, maxSpeed);   
    }
}

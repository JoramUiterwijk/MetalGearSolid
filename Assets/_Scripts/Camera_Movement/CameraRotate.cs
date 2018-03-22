using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Transform newRotation;
    private float rotateSpeed;
    private bool newRotationReached = true;

    public void desiredRotation(Transform ro, float roSpeed = 10)
    {
        newRotation = ro;
        rotateSpeed = roSpeed;
        newRotationReached = false;
    }

	void Update ()
    {
        if (!newRotationReached)
        {
            if (gameObject.transform.localRotation != newRotation.localRotation)
                smoothRotate();
            else
                newRotationReached = true;
        }
    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = Quaternion.Slerp(transform.localRotation, newRotation.localRotation, Time.deltaTime * rotateSpeed);
    }
}

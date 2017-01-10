using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;

    private Vector3 targetPosition;
    private Vector3 velocity;
    private Quaternion targetRotation;

	public void newPosition (Transform newTrans)
    {
     
        targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
	}

	void Update ()
    {
        smoothMove();
    }

    private void smoothMove()
    {
        this.gameObject.transform.position = targetPosition;
        this.gameObject.transform.localRotation = targetRotation;
    }
}

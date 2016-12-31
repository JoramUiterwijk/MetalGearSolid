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
        velocity = newTrans.position - this.gameObject.transform.position;
        velocity.Normalize();
        velocity = velocity * speed;
        //targetPosition = newTrans.position;
        targetRotation = newTrans.localRotation;
	}

	void Update ()
    {
        if(Vector3.Distance(targetPosition,this.gameObject.transform.position) > 0.1)
        smoothMove();
    }

    private void smoothMove()
    {
        this.gameObject.transform.position += velocity * Time.time;
        this.gameObject.transform.localRotation = targetRotation;
    }
}

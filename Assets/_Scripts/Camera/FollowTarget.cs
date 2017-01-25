using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour 
{
	public Transform target;
	public float smoothTime;

	private Vector3 offset;
	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

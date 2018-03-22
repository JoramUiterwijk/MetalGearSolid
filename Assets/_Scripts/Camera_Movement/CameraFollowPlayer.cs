using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject gameobjectRotation;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 playerCameraDistance;

    private Vector3 playerCameraPosion;

    [SerializeField]
    private float maxSpeed = 15;

    [SerializeField]
    private float rotateSpeed = 10;

    private CameraRotate cameraRotate;

    private bool followThePlayer = false;
    private bool newRotationReached = true;

    private void Start()
    {
        cameraRotate = gameObject.GetComponent<CameraRotate>();
    }

    private void Update()
    {
        playerCameraPosion = player.transform.position - playerCameraDistance;

        if (followThePlayer)
        {
            if (Vector3.Distance(playerCameraPosion, this.gameObject.transform.position) > 0.2f)
                smoothMove();
        }        
    }

    public void follow()
    {
        newRotationReached = false;
        followThePlayer = true;
        cameraRotate.desiredRotation(gameobjectRotation.transform, rotateSpeed);
    }

    public void stopFollow()
    {
        newRotationReached = true;
        followThePlayer = false;
    }


    private void smoothMove()
    {
        Vector3 desiredStep = playerCameraPosion - gameObject.transform.position;

        desiredStep.Normalize();

        desiredStep = desiredStep * maxSpeed;

        transform.position += desiredStep * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 playerCameraDistance;

    private Vector3 playerCameraPosion;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float rotateSpeed = 10;

    [SerializeField]
    private Quaternion playerCameraRotation;

    private bool followThePlayer = false;
    private bool newRotationReached = true;

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) > 0.2f && followThePlayer)
            smoothMove();
        //else if (Vector3.Distance(playerCamera.transform.position, this.gameObject.transform.position) <= 0.2)
            //followThePlayer = false;

        if (gameObject.transform.localRotation != player.transform.localRotation && !newRotationReached)
            smoothRotate();
        else
        newRotationReached = true;
    }

    public void follow()
    {
        print("following");
        newRotationReached = false;
        followThePlayer = true;
    }

    public void stopFollow()
    {
        newRotationReached = true;
        followThePlayer = false;
    }


    private void smoothMove()
    {
        Vector3 desiredStep = player.transform.position - gameObject.transform.position;

        desiredStep.Normalize();

        desiredStep = desiredStep * maxSpeed;

        transform.position += desiredStep * Time.deltaTime;

    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = Quaternion.Slerp(transform.rotation, player.transform.localRotation, Time.deltaTime * rotateSpeed);
    }
}

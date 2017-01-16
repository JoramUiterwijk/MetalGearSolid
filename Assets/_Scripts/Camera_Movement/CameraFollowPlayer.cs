using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject gameobjectRotaion;

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
        playerCameraPosion = player.transform.position - playerCameraDistance;

        if (Vector3.Distance(playerCameraPosion, this.gameObject.transform.position) > 0.2f && followThePlayer)
            smoothMove();

        if (gameObject.transform.localRotation != gameobjectRotaion.transform.localRotation && !newRotationReached)
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

        Vector3 desiredStep = playerCameraPosion - gameObject.transform.position;

        desiredStep.Normalize();

        desiredStep = desiredStep * maxSpeed;

        transform.position += desiredStep * Time.deltaTime;

    }

    private void smoothRotate()
    {
        gameObject.transform.localRotation = Quaternion.Slerp(transform.rotation, gameobjectRotaion.transform.localRotation, Time.deltaTime * rotateSpeed);
    }
}

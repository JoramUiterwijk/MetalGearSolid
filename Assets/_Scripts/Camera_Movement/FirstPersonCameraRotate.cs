using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraRotate : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public bool invert;
    private float hozTurn = 0.0f;
    private float verTurn = 0.0f;
    float minRotation = -0.45f;
    float maxRotation = 45f;
    private float currentRotation;

    void Start()
    {
        transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        int invertVal = 1;
        if (invert)
        {
            invertVal = -1;
        }

        currentRotation = transform.localRotation.x;

        hozTurn = Input.GetAxis("CamRotHor") * moveSpeed * Time.deltaTime;
        transform.Rotate(hozTurn * Vector3.up, Space.World);

        print(currentRotation);
        if (currentRotation > minRotation && currentRotation < maxRotation)
        {
            verTurn = Input.GetAxis("CamRotVer") * moveSpeed * Time.deltaTime * invertVal;
            transform.Rotate(verTurn * Vector3.right, Space.Self);
        }
        else
        {
            currentRotation = -0.45f;
        }

        /*Vector3 currentRot = transform.localRotation.eulerAngles;
        currentRot.x =  Mathf.Clamp(currentRot.x, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRot);*/
    }

}

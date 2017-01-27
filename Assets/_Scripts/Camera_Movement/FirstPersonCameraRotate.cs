using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraRotate : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        moveSpeed = 250f;
    }

    void Update()
    {
        float hozTurn = Input.GetAxis("CamRotHor") * moveSpeed * Time.deltaTime;
        transform.Rotate(hozTurn * Vector3.up, Space.World);

        float verTurn = Input.GetAxis("CamRotVer") * moveSpeed * Time.deltaTime * -1;
        transform.Rotate(verTurn * Vector3.right, Space.Self);

        var xRotation = this.transform.eulerAngles.x;
        if (xRotation > 180)
        {
            xRotation -= 360;
        }
        Debug.Log(xRotation);
        this.transform.eulerAngles = new Vector3(Mathf.Clamp(xRotation, -45, 45), this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}

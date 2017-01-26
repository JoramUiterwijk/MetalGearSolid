using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraRotate : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    float maxRotation = 90f;

    void Start()
    {

    }

    void Update()
    {

        float hozTurn = Input.GetAxis("CamRotHor") * moveSpeed * Time.deltaTime;
        transform.Rotate(hozTurn * Vector3.up, Space.World);

        float verTurn = Input.GetAxis("CamRotVer") * moveSpeed * Time.deltaTime * -1;
        transform.Rotate(verTurn * Vector3.right, Space.Self);

        //Vector3 currentRot = transform.localRotation.eulerAngles;
        this.transform.eulerAngles = new Vector3(Mathf.Clamp(this.transform.eulerAngles.x, 0, 45), this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}

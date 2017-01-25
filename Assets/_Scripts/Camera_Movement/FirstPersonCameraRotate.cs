using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraRotate : MonoBehaviour
{

    public float moveSpeed = 20.0f;
    public bool invert;
    private float hozTurn = 0.0f;
    private float verTurn = 0.0f;

    void Update()
    {
        int invertVal = 1;
        if (invert)
        {
            invertVal = -1;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Rotate(verTurn, 0, 0) * moveSpeed * Time.deltaTime;
        }
        //verTurn = Input.GetAxis("CamRotVer") * moveSpeed * Time.deltaTime * invertVal;
        //transform.Rotate(verTurn, hozTurn, 0);

        //transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }
}

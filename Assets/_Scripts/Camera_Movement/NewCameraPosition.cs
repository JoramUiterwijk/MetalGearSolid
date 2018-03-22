using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraPosition : MonoBehaviour
{
    public void newPosition(Transform newTrans)
    {
        if (Vector3.Distance(newTrans.position, this.gameObject.transform.position) > 0.3)
        {
            gameObject.transform.position = newTrans.position;
            gameObject.transform.localRotation = newTrans.localRotation;
        }
            
    }
}

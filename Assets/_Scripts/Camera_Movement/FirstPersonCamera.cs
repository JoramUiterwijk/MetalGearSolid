using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

    private Vector3 _lastCameraPosition;
    private Quaternion _lastCameraRotation;
    //private Transform _lastCameraTransform;

    [SerializeField]
    private GameObject _PlayerEye;
	
	public void setFirstPerson ()
    {
        _lastCameraPosition = gameObject.transform.position;
        _lastCameraRotation = gameObject.transform.localRotation;
      
        gameObject.transform.position = _PlayerEye.transform.position;
        gameObject.transform.localRotation = _PlayerEye.transform.parent.localRotation;
        transform.parent = _PlayerEye.transform;
    }

    public void stopFirstPerson()
    {
        transform.parent = null;
        gameObject.transform.position = _lastCameraPosition;
        gameObject.transform.localRotation = _lastCameraRotation;      
    }
}

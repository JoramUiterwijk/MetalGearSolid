using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    private GameObject _camera;

    private FirstPersonCamera _firstPerson;

    private bool kKeyPresed = false;

	void Start ()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _firstPerson = _camera.GetComponent<FirstPersonCamera>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K) && !kKeyPresed)
        {
            kKeyPresed = true;
            _firstPerson.setFirstPerson();
        }
        if (Input.GetKeyUp(KeyCode.K) && kKeyPresed)
        {
            kKeyPresed = false;
            _firstPerson.stopFirstPerson();
        }
	}
}

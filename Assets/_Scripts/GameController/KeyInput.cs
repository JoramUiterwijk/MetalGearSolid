using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private CameraRegulator _camReg;

    private GameObject _camera;

    private FirstPersonCamera _firstPerson;

    private bool kKeyPresed = false;

    private bool lastFollowing;

	void Start ()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _firstPerson = _camera.GetComponent<FirstPersonCamera>();
        _camReg = _player.GetComponent<CameraRegulator>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K) && !kKeyPresed)
        {
            lastFollowing = _camReg.followingPlayer;

            if (lastFollowing)
            {
                _camReg.followingPlayer = false;
            }

            kKeyPresed = true;
            _firstPerson.setFirstPerson();                   
        }

        if (Input.GetKeyUp(KeyCode.K) && kKeyPresed)
        {
            if (lastFollowing)
            {
                _camReg.followingPlayer = true;
            }

            kKeyPresed = false;
            _firstPerson.stopFirstPerson();
        }
	}
}

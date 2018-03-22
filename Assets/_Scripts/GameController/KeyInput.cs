using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private CameraRegulator _camReg;

    private GameObject _camera;

    [SerializeField]
    private GameObject _camRotator;

    private FirstPersonCamera _firstPerson;

    private PlayerController _playerController;

    private FirstPersonCameraRotate _firstPersonCameraRotate;

    private bool kKeyPresed = false;

    private bool lastFollowing;

    private bool PlayerEnabled;

	void Start ()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _firstPerson = _camera.GetComponent<FirstPersonCamera>();
        _camReg = _player.GetComponent<CameraRegulator>();
        _playerController = _player.GetComponent<PlayerController>();
        _firstPersonCameraRotate = _camRotator.GetComponent<FirstPersonCameraRotate>();

        _firstPersonCameraRotate.enabled = false;
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
            _playerController.enabled = false;
            _player.GetComponent<SkinnedMeshRenderer>().enabled = false;
            kKeyPresed = true;
            _firstPerson.setFirstPerson();
            _firstPersonCameraRotate.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.K) && kKeyPresed)
        {
            if (lastFollowing)
            {
                _camReg.followingPlayer = true;
            }
            _player.GetComponent<SkinnedMeshRenderer>().enabled = true;
            _firstPersonCameraRotate.enabled = false;
            _firstPersonCameraRotate.transform.eulerAngles = Vector3.zero;
            _playerController.enabled = true;
            kKeyPresed = false;
            _firstPerson.stopFirstPerson();
        }


	}
}

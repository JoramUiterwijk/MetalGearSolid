using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    private MoveCamera moveCamera;
    private NewCameraPosition newCamPosition;

	private void Start ()
    {
        moveCamera = cam.GetComponent<MoveCamera>();
        newCamPosition = cam.GetComponent<NewCameraPosition>();
    }

    private void OnTriggerEnter(Collider other)
    {              
        if (other.CompareTag(Tags.newPosition))
        {
            setTargetPosition(other.gameObject);
        }
            
        if (other.CompareTag(Tags.newRoom))
        {
            setNewPosition(other.gameObject);
        }               
    }

    private void setTargetPosition(GameObject other)
    {
        Transform child = other.transform.Find("NewPosition");
        moveCamera.newPosition(child);
    }

    private void setNewPosition(GameObject other)
    {
        Transform child = other.transform.Find("NewPosition");
        newCamPosition.newPosition(child);
    }
}

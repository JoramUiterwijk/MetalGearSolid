using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField]
    private string[] tags;

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
        
        if(tags.Length - 1 >= 0)
        {
            if (other.CompareTag(tags[0]))
            {
                setTargetPosition(other.gameObject);
            }
            else if (tags.Length - 1 >= 1)
            {
                if (other.CompareTag(tags[1]))
                {
                    setNewPosition(other.gameObject);
                }
            }
        }       
        else
        {
            Debug.LogWarning("no tags asignt");
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

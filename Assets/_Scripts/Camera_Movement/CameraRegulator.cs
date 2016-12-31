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

	private void Start ()
    {
        moveCamera = cam.GetComponent<MoveCamera>();
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(tags.Length - 1 >= 0)
        {
            if (other.CompareTag(tags[0]))
            {
                setNewPosition(other.gameObject);
            }
        }
        else
        {
            Debug.Log("no tags asignt");
        }
        
    }

    private void setNewPosition(GameObject other)
    {
        Transform child = other.transform.Find("NewPosition");
        moveCamera.newPosition(child);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    private MoveCamera moveCamera;
    private CameraFollowPlayer followPlayer;
    private NewCameraPosition newCamPosition;

    private bool first = true;

    public bool followingPlayer = false;

	private void Start ()
    {
        moveCamera = cam.GetComponent<MoveCamera>();
        followPlayer = cam.GetComponent<CameraFollowPlayer>();
        newCamPosition = cam.GetComponent<NewCameraPosition>();
    }

    private void Update()
    {
        if (followingPlayer)
        {
            followThePlayer();
        }
        if (!followingPlayer)
        {
            stopFollowing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (!first)
            {
                findTag(other);
            }
            else
            {
                firstTag(other);
            }             
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.CompareTag(Tags.followPlayer))
            {
                followingPlayer = false;
            }       
    }

    private void firstTag(Collider other)
    {
        if (other.CompareTag(Tags.newPosition) || other.CompareTag(Tags.newRoom))
        {
            setNewPosition(other.gameObject);
            first = false;
        }
    }

    private void findTag(Collider other)
    {
        if (other.CompareTag(Tags.newPosition))
        {
            setTargetPosition(other.gameObject);
        }

        if (other.CompareTag(Tags.newRoom))
        {
            setNewPosition(other.gameObject);
        }

        if (other.CompareTag(Tags.followPlayer))
        {
            followingPlayer = true;
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

    private void followThePlayer()
    {
        followPlayer.follow();
    }

    public void stopFollowing()
    {
        followPlayer.stopFollow();
    }

}

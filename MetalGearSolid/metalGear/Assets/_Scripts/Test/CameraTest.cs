using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float distance;

	void Update ()
    {
		if(target != null)
        {
            this.transform.position = target.transform.position + new Vector3(0, 0, distance);
            this.transform.rotation = target.transform.rotation;
        }
	}
    public void otherPlayer(GameObject player)
    {
        target = player;
    }
}

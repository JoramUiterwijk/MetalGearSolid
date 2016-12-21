using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float y = 0f;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 250.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, y, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = 1f;
        }
        else
        {
            y = 0f;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == ("Stairs"))
        {
            y += 1;
            Debug.Log("Up!");
        }
        else
        {
            y = 0f;
        }
    }
}
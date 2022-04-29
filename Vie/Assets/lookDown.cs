using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookDown : MonoBehaviour
{
    private cameraFollow cam;

    private void Awake()
    {
        cam = GetComponent<cameraFollow>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Debug.Log("Down!");
            cam.offSet.y = -2;
        }
        else
        {
            Debug.Log("Not holding down");
            if (cam.offSet.y != 2) cam.offSet.y = 2;

        }
    }
}

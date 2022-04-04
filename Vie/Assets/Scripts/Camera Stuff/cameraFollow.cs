using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // what to follow
    public Transform target;

    // how fast the camera locks onto target. range of 0-1 is best
    public float smoothSpeed = 0.125f;

    // Normally the camera will be inside the player so we must offset it by a bit
    public Vector3 offSet;

    // we want to move the camera after the player has moved (which happends in an update).
    // so we use late update which occurs after updates have finished.
    void FixedUpdate()
    {
        // store the player's position modifyed by the offest 
        Vector3 desiredPosition = target.position + offSet;

        //Get a bit closer to the players position but ease into it
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // make the modifyed smoothed positioin become the camera's position
        transform.position = smoothedPosition;
    }
}

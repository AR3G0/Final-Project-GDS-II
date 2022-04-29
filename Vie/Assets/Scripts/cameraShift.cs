using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShift : MonoBehaviour
{
    public float speed;

    public GameObject cameraObject;
    private Camera cam;
    private cameraFollow camFollow;
    private lookDown camLookDown;

    private bool fadeIn = false;

    private void Awake()
    {
        cam = cameraObject.GetComponent<Camera>();
        camFollow = cameraObject.GetComponent<cameraFollow>();
        camLookDown = cameraObject.GetComponent<lookDown>();
    }

    // when the player enters the trigger exapand the camera upwards
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            //turn off the abilighty to look down so the player does not fuck with the shroom cam
            camLookDown.activeFlag = false;  
            
            // start expaning the camera
            fadeIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //turn back on the abilighty to look down
            camLookDown.activeFlag = true;

            fadeIn = false;

        }
    }


    private void FixedUpdate()
    {
        //when the player enters the trigger, start expanding the camera
        if (fadeIn == true)
        {
            //slowly move the camera upwards
            if (camFollow.offSet.y < 4)
            {
                camFollow.offSet.y += speed;
            }
            else
            {
                camFollow.offSet.y = 4;
            }

            // expand the camera outwards
            if (cam.orthographicSize < 15)
            {
                cam.orthographicSize += speed * 2;
            }
            else
            {
                cam.orthographicSize = 15;
            }
        }
        // if the player leaves the circle, shrink the camera back to normal
        else
        {
            //slowly move the camera upwards
            if (camFollow.offSet.y > 2)
            {
                camFollow.offSet.y -= speed;
            }
            else
            {
                camFollow.offSet.y = 2;

                //turn back on the abilighty to move the camera downward
                camLookDown.gameObject.SetActive(true);
            }


            if (cam.orthographicSize > 5)
            {
                cam.orthographicSize -= speed * 2;
            }
            else
            {
                cam.orthographicSize = 5;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushroomGrowth : MonoBehaviour
{
    // growth needs to be between 1 and 0
    public float growth = 1f;
    public float maxSpeed = 0.5f;
    public float speed = 0f;
    public float acc = 0.125f;

    //check to see if the player is looking at the object or not
    private bool playerLookingAt = false;

    // get the slider componet so we can refence the balance bar's value latter
    private GameObject slider;

    private void Awake()
    {
        slider = GameObject.Find("balanceBar");
    }

    //while the player is looking at the vines, turn on the flag.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lightCone")
        {
            playerLookingAt = true;
        }
    }

    //when the player stops looking at the vines, turn off the flag
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "lightCone")
        {
            playerLookingAt = false;
        }
    }


    private void FixedUpdate()
    {

        if (playerLookingAt == true)
        {
            var sliderComponet = slider.GetComponent<Slider>();
            // if there is more light then dark move the mushroom
            if (sliderComponet.value < 51f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);

                //acceleart up to speed
                if (speed < maxSpeed) speed += acc;
            }
        }
        else
        {
            if (speed > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
                //decelerat
                speed -= acc*2;
            }
        }
    }
}

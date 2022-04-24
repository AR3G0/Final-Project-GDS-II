using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seaweedPlaformGrowth : MonoBehaviour
{
    // growth needs to be between 1 and 0
    public float growth = 1f;
    public float maxSpeed;
    public float speed;
    public float acc; 

    // link all the vine objects we will move later
    public GameObject seaweed;
    public GameObject platform;

    //check to see if the player is looking at the object or not
    private bool playerLookingAt = false;
    // init a array of game objects for the vines
    private GameObject[] vines;
    // get the slider componet so we can refence the balance bar's value latter
    private GameObject slider;


    private float counterGrowth = 1f;


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
            speed = 0.0005f; 
        }
    }


    private void FixedUpdate()
    {
        // while the player is looking at the vines, grow or wither them
        if (playerLookingAt == true)
        {
            // get the slider componet so we can check for the balance bar's value
            GameObject slider = GameObject.Find("balanceBar");
            Slider balanceValue = slider.GetComponent<Slider>();

            // if there is more dark then light, wither the plants
            if (balanceValue.value >= 50)
            {
                if (growth > 0.2f)
                {
                    if (speed < maxSpeed) speed += acc;
                    else speed = maxSpeed;

                    // slowly wither the plants
                    growth -= speed;

                    //lower the platform
                    platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y - speed * 6, platform.transform.position.z);
                }
                else
                {
                    Destroy(gameObject);
                    growth = 0.2f;
                }
            }
            /// if there is more light then dark, grow the plants back
            else
            {
                // cap the growth at 1
                if (growth < 1)
                {

                    if (speed < maxSpeed) speed += acc;
                    else speed = maxSpeed;

                    // slowly grow the plants
                    growth += speed;

                    //raise the platform
                    platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + speed * 6, platform.transform.position.z);
                }
                else
                {
                    growth = 1;
                }
            }

            // set the seaweed's scale to whatever the growth value is.
            seaweed.transform.localScale = new Vector3(seaweed.transform.localScale.x, growth, seaweed.transform.localScale.z);
        }
        // if the player is not looking at the object 
        // and if the object needs to be reset
        else
        {
            // if the objects scale is not the same as the growth value (like if it was just spawned in) make those the same.
            if (seaweed.transform.localScale.y != growth)
            {
                    // we only care about values that are greater then .2 and smaller then 1.
                    if (counterGrowth > 0.2f)
                    {
                        if (speed < maxSpeed) speed += acc;
                        else speed = maxSpeed;

                        counterGrowth -= speed;    

                        //lower the platform
                        platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y - speed * 6, platform.transform.position.z);

                        // set the seaweed's scale to whatever the growth value is.
                        seaweed.transform.localScale = new Vector3(seaweed.transform.localScale.x, counterGrowth, seaweed.transform.localScale.z);
                    }
                    else
                    {
                        speed = 0.0005f;
                        counterGrowth = 0.2f;
                    }


            }
        }

    }
}

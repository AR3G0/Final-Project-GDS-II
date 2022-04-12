using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushroomGrowth : MonoBehaviour
{
    // growth needs to be between 1 and 0
    public float growth = 1f;
    public float speed = 0.0125f;

    // link all the vine objects we will move later
    public GameObject platform;

    public float acc;

    //check to see if the player is looking at the object or not
    private bool playerLookingAt = false;

    // get the slider componet so we can refence the balance bar's value latter
    private GameObject slider;

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


    private void Update()
    {

        if (playerLookingAt == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed/acc, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipScript : MonoBehaviour
{
    // when the player colides with the pip it dies but addes 10 points to the player
    public bool isPipDark = true;

    public float bobSpeed = 0.125f;
    public float maxBobHeight = 3f;
    private bool goingUp = true;
    private float startingPosition;

    // get the balance bar so we can modify it
    public GameObject balanceBar;

    private void Awake()
    {
        startingPosition = transform.position.y;
    }

    private void FixedUpdate()
    {
        bob();
    }

    // if the player runs into the pip, destory it and add or subtract 10 darkness.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var script = balanceBar.GetComponent<balanceBarController>();

            // if the pip is dark add 10 points but if it is light subtract 10 points
            if (isPipDark == true)
            {
                script.darknessValue += 10f;
            }
            else
            {
                script.darknessValue -= 10f;
            }

            Destroy(gameObject);
        }
    }

    private void bob()
    {

        /*
        if (goingUp == true && transform.position.y < startingPosition + maxBobHeight)
        {
            transform.position += new Vector3(transform.position.x, transform.position.y + bobSpeed, transform.position.z);

            if (transform.position.y >= startingPosition + maxBobHeight) goingUp = false;
        }
        else if (goingUp == false && transform.position.y > startingPosition - maxBobHeight)
        {
            transform.position += new Vector3(transform.position.x, transform.position.y - bobSpeed, transform.position.z); ;
        }
        */
    }
}

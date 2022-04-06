using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipScript : MonoBehaviour
{
    // when the player colides with the pip it dies but addes 10 points to the player
    public bool isPipDark = true;

    // range 0-1;
    public float bobAmplitue;
    //this is like the speed (frececy of the wave)
    public float bobFrequency;

    // the orginal positioin of the vector that the math is relative to.
    Vector3 initPos;

    // get the balance bar so we can modify it
    public GameObject balanceBar;

    private void Start()
    {
        initPos = transform.position;  
    }

    private void Update()
    {
        // this is actually a really cool formula. Basically we are moving the sprite up and down along a sin wave and
        // using amplitue to measue the heigh of the bob and frequency to measure the speed.
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * bobFrequency) * bobAmplitue + initPos.y, initPos.z);
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


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackPipScript : MonoBehaviour
{
    // range 0-1;
    public float bobAmplitue;
    //this is like the speed (frececy of the wave)
    public float bobFrequency;

    // the orginal positioin of the vector that the math is relative to.
    private Vector3 initPos;

    // get the balance bar so we can modify it
    public GameObject balanceBar;

    public GameObject Deathparticles;

    private void Awake()
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

            script.darknessValue += 10f;

            GameObject newParts = Instantiate(Deathparticles, transform.position, transform.rotation);
            //newParts.transform.parent = other.transform;

            Destroy(gameObject);
        }
    }


}

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

    public AudioClip growSound;
    public AudioClip witherSound;

    //check to see if the player is looking at the object or not
    private bool playerLookingAt = false;

    private AudioSource audioPlayer;
    private GameObject balanceSlider;
    private Slider balanceValue;


    private void Start()
    {
        // get the slider componet so we can check for the balance bar's value
        balanceSlider = GameObject.Find("balanceBar");
        balanceValue = balanceSlider.GetComponent<Slider>();

        audioPlayer = GetComponent<AudioSource>();
    }


    //while the player is looking at the vines, turn on the flag.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lightCone")
        {

            if (!audioPlayer.isPlaying)
            {
                //wither sound
                if (balanceValue.value > 50)
                {
                    audioPlayer.clip = witherSound;
                    audioPlayer.volume = 0;
                    audioPlayer.Play();
                }
                // growing sound
                else
                {
                    audioPlayer.clip = growSound;
                    audioPlayer.volume = 0;
                    audioPlayer.Play();
                }
            }

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
            var sliderComponet = balanceSlider.GetComponent<Slider>();
            // if there is more light then dark move the mushroom
            if (sliderComponet.value < 51f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);

                //acceleart up to speed
                if (speed < maxSpeed) speed += acc;

                //increase the volume as the player looks at the plant
                if (audioPlayer.volume < 1) audioPlayer.volume += speed * 16;
                else audioPlayer.volume = 1;
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

            //decrease the volume as the player looks away
            if (audioPlayer.volume > 0)
            {
                audioPlayer.volume -= speed * 16;
            }
            else
            {
                audioPlayer.volume = 0;
                audioPlayer.Stop();
            }
        }
    }
}

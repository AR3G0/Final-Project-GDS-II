using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vineWallGrowth : MonoBehaviour
{
    // growth needs to be between 1 and 0
    public float growth = 1f;
    public float maxSpeed;
    public float speed;
    public float acc;

    // link all the vine objects we will move later
    public GameObject wall;
    public GameObject vine1;
    public GameObject vine2;
    public GameObject seaWeed1;
    public GameObject seaWeed2;
    public AudioClip growSound;
    public AudioClip witherSound;

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
        // while the player is looking at the vines, grow or wither them
        if (playerLookingAt == true)
        {
            // create an array that stores all of the vine objects
            GameObject[] vines = { vine1, vine2, seaWeed1, seaWeed2 };

            // if there is more dark then light, wither the plants
            if (balanceValue.value >= 50)
            {
                if (growth > 0.2f)
                {
                    if (speed < maxSpeed) speed += acc;
                    else speed = maxSpeed;

                    // slowly wither the plants
                    growth -= speed;
                }
                else
                {
                    Destroy(gameObject);
                    growth = 0.2f;
                }

                //increase the volume as the player looks at the plant
                if (audioPlayer.volume < 1) audioPlayer.volume += speed * 16;
                else audioPlayer.volume = 1;
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
                }
                else
                {
                    growth = 1;
                }
            }

            // if the plant is mostly withered, turn off the invisable wall.
            if (growth <= 0.35f)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }

            // scale the vines down on the y axis relative to the growth float.
            foreach (GameObject vine in vines)
            {
                vine.transform.localScale = new Vector3(vine.transform.localScale.x, growth, vine.transform.localScale.z);
            }
        }
        else
        {
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

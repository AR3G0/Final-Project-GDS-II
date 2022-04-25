using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public float volume = 1;
    public float triggerRange;

    public pipScript pip;
    public AudioClip lightPickUp;
    public AudioClip DarkPickUp;
    public AudioClip lightAmb;
    public AudioClip DarkAmb;


    private AudioClip pickUp;
    private AudioClip amb;

    private AudioSource audioPlayer;

    private GameObject player;

    private void Start()
    {
        if (pip.isPipDark == false)
        {
            // turn on light sounds.
            pickUp = lightPickUp;
            amb = lightAmb;
        }
        else
        {
            // turn on dark sounds.
            pickUp = DarkPickUp;
            amb = DarkAmb;
        }

        gameObject.GetComponent<AudioSource>().clip = amb;

        AudioSource audioPlayer = gameObject.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < triggerRange)
        {
           // if (audioPlayer.isPlaying != true) audioPlayer.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) AudioSource.PlayClipAtPoint(pickUp, transform.position, volume);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackPipAudio : MonoBehaviour
{
    public float volume = 1;
    public float fadeInSpeed = 0.025f;
    public float triggerRange;

    public AudioClip pickUp;

    public GameObject player;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        audioPlayer.Stop();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < triggerRange)
        {
            if (audioPlayer.isPlaying != true) audioPlayer.Play();

            //fade in audio as the player comes close
            if (audioPlayer.volume < 1)
            {
                audioPlayer.volume += fadeInSpeed;
            }
            else
            {
                audioPlayer.volume = 1;
            }
        }
        else
        {
            //fade out audio if the player is out of range
            if(audioPlayer.volume > 0)
            {
                audioPlayer.volume -= fadeInSpeed;
            }
            else
            {
                audioPlayer.volume = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") AudioSource.PlayClipAtPoint(pickUp, transform.position, volume);
    }
}

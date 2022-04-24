using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateParts : MonoBehaviour
{
    public GameObject particles;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = particles.GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "interactable" )
        {
            particleSystem.Play();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interactable")
        {
            particleSystem.Stop();
        }
    }
}

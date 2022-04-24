using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class worldObjPartOn : MonoBehaviour
{
    public GameObject part;
    public GameObject balanceBar;
    private ParticleSystem particleSystem;
    private Slider slider;

    private void Awake()
    {
        particleSystem = part.GetComponent<ParticleSystem>();
        particleSystem.Stop();

        //get a refence to the slider's value
        slider = balanceBar.GetComponent<Slider>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "lightCone")
        {
            // Change the color 
            var main = particleSystem.main;
            if (slider.value > 50) main.startColor = new Color(0, 0, 0, 1);
            else main.startColor = new Color(1, 1, 1, 1);

            //turn on the particles
            particleSystem.Play();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "lightCone")
        {
            particleSystem.Stop();
        }
    }
}

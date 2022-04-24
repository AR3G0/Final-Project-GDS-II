using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vineWallPartOn : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject balanceBar;
    private ParticleSystem particleSystem1;
    private ParticleSystem particleSystem2;
    private Slider slider;

    private void Awake()
    {
        particleSystem1 = part1.GetComponent<ParticleSystem>();
        particleSystem1.GetComponent<ParticleSystem>().Stop();

        particleSystem2 = part2.GetComponent<ParticleSystem>();
        particleSystem2.GetComponent<ParticleSystem>().Stop();

        //get a refence to the slider's value
        slider = balanceBar.GetComponent<Slider>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "lightCone")
        {
            // Change the color 
            var main = particleSystem1.main;
            if (slider.value > 50) main.startColor = new Color(0, 0, 0, 1);
            else main.startColor = new Color(1, 1, 1, 1);

            var main2 = particleSystem2.main;
            if (slider.value > 50) main2.startColor = new Color(0, 0, 0, 1);
            else main2.startColor = new Color(1, 1, 1, 1);

            //turn on the particles
            particleSystem1.Play();
            //turn on the particles
            particleSystem2.Play();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "lightCone")
        {
            particleSystem1.Stop();
            particleSystem2.Stop();
        }
    }
}

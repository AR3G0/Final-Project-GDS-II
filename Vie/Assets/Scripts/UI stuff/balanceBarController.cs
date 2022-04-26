using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class balanceBarController : MonoBehaviour
{
    // this number determines how much darkness fills up the bar and is used to trigger which light is active.
    public float darknessValue = 0f;
    public float sliderSpeed = 0.125f;
    public Slider slider;

    private Shaker shaker;

    private void Awake()
    {
        shaker = GetComponent<Shaker>();
    }

    public void FixedUpdate()
    {
        if (slider.value < darknessValue)
        {
            slider.value += sliderSpeed;
            shaker.shake(0.05f);
        }
        else if (slider.value > darknessValue)
        {
            slider.value -= sliderSpeed;
            shaker.shake(0.05f);
        }
        else if (slider.value == darknessValue)
        {
            shaker.shake(0);
        }
    }
}

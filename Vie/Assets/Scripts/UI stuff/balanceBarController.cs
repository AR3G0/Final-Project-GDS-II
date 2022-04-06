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



    public void FixedUpdate()
    {
        if (slider.value < darknessValue)
        {
            slider.value += sliderSpeed;
        }
    }
}

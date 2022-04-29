using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeToBlack : MonoBehaviour
{
    public float speed;

    private Image image;

    private float newAlpah = 0;

    private void Awake()
    {
        image = GetComponent<Image>();

    }

    public void setAlphaTo(float a)
    {
        newAlpah = a;
        image.color = new Color(image.color.r, image.color.g, image.color.b, a);
    }

    public void fadeBlackIn() 
    {
        if (image.color.a < 1)
        {
            
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpah);
            newAlpah = newAlpah + speed;

        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
    }

    public void fadeBlackOut()
    {
        if (image.color.a > 0)
        {

            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpah);
            newAlpah = newAlpah - speed;
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightModeSwitch : MonoBehaviour
{
    public GameObject balanceBar;
    public SpriteRenderer spriteRenderer;

    public bool isDark = false;

    private void Update()
    {
       Slider barValue = balanceBar.GetComponent<Slider>();

        // if the cone is set to light, switch it to dark
        if (isDark == false && barValue.value >= 50)
        {
            spriteRenderer.color = new Color(0, 0, 0, 1);
            isDark = true;

        }
        // If the cone is set to dark, switch it to light.
        else if (isDark == true && barValue.value < 50)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
            isDark = false;
        }
    }

}

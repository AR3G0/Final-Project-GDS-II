using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coneParticleDirection : MonoBehaviour
{
    // the speed at which the particles follow the mouse
    public float speed;
    public GameObject lightCone;
    private Transform targetTransform;

    private bool isDarkPart;

    private lightModeSwitch lightmode;

    private ParticleSystem m_particles;

    private void Awake()
    {
        targetTransform = lightCone.GetComponent<Transform>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        lightModeSwitch lightmode = lightCone.GetComponent<lightModeSwitch>();

        ParticleSystem m_particles = GetComponent<ParticleSystem>();

        var main = m_particles.main;

        if (lightmode.isDark == true && isDarkPart == false)
        {
            main.startColor = new Color(0, 0, 0, 1);
            isDarkPart = true;
        }
        else if (lightmode.isDark == false && isDarkPart == true)
        {
            main.startColor = new Color(1, 1, 1, 1);
            isDarkPart = false;
        }

        ////////// MATH TO FOLLOW MOUSE //////////
        #region
        // convert the mouses location on the screen to an x, y position in the world.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // get the angle between the object and the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // roate the light beam based on the angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // smooth out the movement
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        #endregion

        transform.position = targetTransform.position;
    }
}

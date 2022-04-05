using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightToFollow : MonoBehaviour
{
    // the speed at which the object follows the mouse
    public float speed = 5f;

    private GameObject player;
    // private CharacterController2D controllerScript;

    private void Awake()
    {
        // get the parent player object so we can check it's transform position latter.
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ////////// MATH TO FOLLOW MOUSE //////////
        // convert the mouses location on the screen to an x, y position in the world.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // get the angle between the object and the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // roate the light beam based on the angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // smooth out the movement
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

}

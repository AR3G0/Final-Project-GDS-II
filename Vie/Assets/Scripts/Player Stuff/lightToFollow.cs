using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightToFollow : MonoBehaviour
{
    // the speed at which the object follows the mouse
    public float speed = 5f;

    // what to follow
    public Transform target;

    public playerMovement movementScript;

    // a bool to see if the player and light direction matchs
    private bool lightIsRight = true;



    // Update is called once per frame
    void FixedUpdate()
    {
        // follow the player around
        transform.position = target.position;

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

        ////////// FLIP BEAM WITH PLAYER MOVEMENT //////////
        //get the mouse's position and convert it to a verctor 3.

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // store the mouse's x position in the world as a float 
        float PosX = mousePos.x;

        // do the same as above but with the player's position
        float playerX = target.position.x;


        // Below we keep track of what side of the player the light beam is on based on the mouses relation to the player

        // if the player is facing left but the mouse is on the right, flip the sprite.
        if (!lightIsRight && PosX > playerX)
        {
            lightIsRight = true;
        }
        // if the player is facing right but the mouse is on the left, flip the sprite.
        else if (lightIsRight && PosX < playerX)
        {
            lightIsRight = false;
        }

        
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // get the controller script so we can tell it to do stuff later
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;



    // used to control the player flipping with the mouse
    private bool facingRight = true;

    public GameObject lightBeam;

    // Get input from player
    void Update()
    {
        // returns -1 || 1 based on player input 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    // apply input from player to character
    void FixedUpdate()
    {
        // move, no jump, no crouch
        // Time.fixedDeltaTime keeps things consistent.
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        ////////// FlIP THE PLAYER WITH MOUSE //////////
        ///
        //get the mouse's position and convert it to a verctor 3.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // store the mouse's x position in the world as a float 
        float PosX = mousePos.x;
        // do the same as above but with the player's position
        float playerX = transform.position.x;

        // get the renderer componet from the Sprite light beam so we can change it's origin later
        SpriteRenderer lightBeamRenderer = lightBeam.GetComponent<SpriteRenderer>();

        // if the player is facing left but the mouse is on the right, flip the sprite.
        if (!facingRight && PosX > playerX)
        {
            controller.Flip();
            facingRight = true;
        }
        // if the player is facing right but the mouse is on the left, flip the sprite.
        else if (facingRight && PosX < playerX)
        {
            controller.Flip();
            facingRight = false; 
        }
    }
}

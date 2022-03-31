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
    }
}

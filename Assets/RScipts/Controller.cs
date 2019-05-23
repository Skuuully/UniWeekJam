 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour {

    // publics
    public float movement; // a modifier to the movespeed
    public bool P1; // check to p1 if player1, used for inputs

    // privates
    private CharacterController characterController;
    float moveModifier; // use to set movement to be slower during certain actions
    float damageReceivedModifier; // used to take less damage whilst blocking

    float x; // move horizontal
    float z; // move vertical
    float block; // if blocking
    bool blocking; // use for other scripts

	void Start ()
    {
        characterController = GetComponent<CharacterController>();
        moveModifier = 1.0f;
        damageReceivedModifier = 1.0f;
	}
	
	void Update ()
    {
        LockY();
        CheckBlock();
        CheckMove();
    }

    void FixedUpdate()
    {
        Block();
        Move();
    }

    // check if the player is inputting movement
    void CheckMove()
    {
        if (P1)
        {
             x = Input.GetAxis("Horizontal");
             z = Input.GetAxis("Vertical");
        }
        else
        {
             x = Input.GetAxis("P2Horizontal");
             z = Input.GetAxis("P2Vertical");
        }

    }

    // move the player based on key press and moveModifier
    void Move()
    {
        Vector3 Forward = new Vector3(0.0f, 0.0f, 1.0f); // lower caps f seems to use trasforms right instead
        Vector3 Right = new Vector3(1.0f, 0.0f, 0.0f);
        characterController.Move(Right * x * movement * moveModifier);
        characterController.Move(Forward * z * movement * moveModifier);
    }

    // gets the input for the block button
    void CheckBlock()
    {
        if(P1)
        {
            block = Input.GetAxis("Block");
        }
        else
        {
            block = Input.GetAxis("P2Block");
        }
        Block();
    }

    // if button pressed slow movement and reduce damage taken
    void Block()
    {
        if(block > 0)
        {
            moveModifier = 0.5f;
            damageReceivedModifier = 0.5f;
            blocking = true;
        }
        else
        {
            moveModifier = 1.0f;
            damageReceivedModifier = 1.0f;
            blocking = false;
        }
    }

    // for dmg script to get the value to multiply damage by
    public float GetDamageReceivedModifier()
    {
        return damageReceivedModifier;
    }

    void LockY()
    {
        Vector3 currentPos = transform.position;
        currentPos.y = 0.55f;
        transform.position = currentPos;
    }

    public bool Blocking()
    {
        return blocking;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // privates
    GameObject[] players;
    public bool p2punch;
    public bool p1punch;
    Stamina p1Stamina;
    Stamina p2Stamina;
    Controller p1Block;
    Controller p2Block;
    int x = 0;
    int y = 0;
    float attackStaminaCost = 25.0f;
    void Start()
    {
        // get the players, assumes only 2 players
        players = GameObject.FindGameObjectsWithTag("Player");
        // if 1st is player1 set p1Stamina to 1st player
        if(players[0].GetComponent<Controller>().P1)
        {
            p1Stamina = players[0].GetComponent<Stamina>();
            p2Stamina = players[1].GetComponent<Stamina>();
            p1Block = players[0].GetComponent<Controller>();
            p2Block = players[1].GetComponent<Controller>();

        }
        // else do it the other way
        else
        {
            p1Stamina = players[1].GetComponent<Stamina>();
            p2Stamina = players[0].GetComponent<Stamina>();
            p1Block = players[1].GetComponent<Controller>();
            p2Block = players[0].GetComponent<Controller>();
        }
    }
    void FixedUpdate()
    {
        if (x > 0)
        {
            x -= 1;
        }
        if (y > 0)
        {
            y -= 1;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Punch") && x <= 0)
        {
            // if player 1 has enough stamina to attack
            if (p1Stamina.EnoughStamina(attackStaminaCost) && !p1Block.Blocking())
            {
                //x = 20;
                p1punch = true;
                p1Stamina.RemoveStamina(attackStaminaCost);
            }

        }
        else if (Input.GetButtonDown("P2Punch") && y <= 0 && !p2Block.Blocking())
        {
            // if player 2 had enough stamina to attack
            if (p2Stamina.EnoughStamina(attackStaminaCost))
            {
                //x = 20;
                p2punch = true;
                p2Stamina.RemoveStamina(attackStaminaCost);
            }
        }
    }
}
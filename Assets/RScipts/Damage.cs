using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    // publics
    public float damageDealt;

    // privates
    float attackDamage = 1;
    float beatMultiplier;
    float beatMultiplierDamage = 5;
    GameObject[] players;
    float x;
    
	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Attack()
    {
        float dmgOpponentTakesMulti = 1.0f;
        float stamCost = -1.0f;
        // get the opponents dmg received multiplier, so if blocking they will take less as multi will be <1
        if(name == "Player1")
        {
            dmgOpponentTakesMulti = players[1].GetComponent<Controller>().GetDamageReceivedModifier();
            stamCost = players[0].GetComponent<Stamina>().LastCost();
        }
        else
        {
            dmgOpponentTakesMulti = players[0].GetComponent<Controller>().GetDamageReceivedModifier();
            stamCost = players[1].GetComponent<Stamina>().LastCost();
        }

        // get if in the beat for a different damage multi
        if (stamCost == 0)
        {
            beatMultiplier = beatMultiplierDamage;
        }
        else
        {
            beatMultiplier = 1.0f;
        }

        float damageToDeal = attackDamage * beatMultiplier * dmgOpponentTakesMulti;
        damageDealt += damageToDeal;
    }

    public void ResetDamage()
    {
        damageDealt = 0;
    }
}
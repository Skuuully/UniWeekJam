using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

    // publics
    public float staminaRegenCooldown;
    public float maxStamina;
    public float regenRate;
    public float minStaminaToAttack;
    public float stamina;

    // privates
    float timeOfLastAction;
    Beats beats;
    float lastStaminaCost; // used for determining dmg multi

	// Use this for initialization
	void Start ()
    {
        stamina = maxStamina;
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timeOfLastAction + staminaRegenCooldown < Time.time)
        {
            RegenerateStamina();
        }
    }

    // call this to remove stamina, checks will be done for if stamina can be removed or not
    public void RemoveStamina(float staminaCost)
    {
        if(beats.DamageTime())
        {
            staminaCost = 0.0f;
        }
        if (EnoughStamina(staminaCost))
        {
            stamina -= staminaCost;
            if (stamina < 0)
            {
                stamina = 0;
            }
            timeOfLastAction = Time.time;
        }
        lastStaminaCost = staminaCost;
    }

    // check if a value will be too large to be removed from the stamina pool
    public bool EnoughStamina(float staminaCost)
    {
        if(stamina < minStaminaToAttack)
        {
            return false;
        }
        
        return true;
    }

    // used to regen stamina if no attacks have happened recently
    void RegenerateStamina()
    {
        if(stamina < maxStamina)
        {
            stamina += regenRate;
        }
    }

    public float LastCost()
    {
        return lastStaminaCost;
    }
}

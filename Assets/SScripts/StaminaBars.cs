using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBars : MonoBehaviour {

    public Stamina staminaScript;

    private Image staminaBar;

    float amountToFill;
    float stamina;



    private void Start()
    {
        staminaBar = GetComponent<Image>();
    }

    private void Update()
    {
        stamina = staminaScript.stamina;
        amountToFill = stamina / staminaScript.maxStamina;
        staminaBar.fillAmount = amountToFill;
        if (staminaScript.stamina > staminaScript.minStaminaToAttack)
        {
            staminaBar.color = Color.green;
        }
        else
        {
            staminaBar.color = Color.red;
        }
    }
}

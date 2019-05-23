using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {
    private Animator anima;

	// Use this for initialization
	void Start () {
        anima = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float block = Input.GetAxis("Block");


        // if stood still
        if (vertical == 0 && horizontal == 0)
        {
            anima.SetInteger("condition", 0);
        }
        // else handle directional animation
        else
        {
            if (vertical > 0)
            {
                anima.SetInteger("condition", 1);
            }
            else if (vertical < 0)
            {
                anima.SetInteger("condition", 2);
            }

            if (horizontal > 0)
            {
                anima.SetInteger("condition", 4);
            }
            else if (horizontal < 0)
            {
                anima.SetInteger("condition", 3);
            }
            
           
        }
        if (block != 0)
        {
            anima.SetInteger("condition", 6);
        }

    }
}

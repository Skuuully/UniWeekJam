using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animae : MonoBehaviour
{
    private Animator anima;
    // Use this for initialization
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float P2vertical = Input.GetAxis("P2Vertical"); // get vert movement
        float P2horizontal = Input.GetAxis("P2Horizontal"); // get horizontal movement
        float block = Input.GetAxis("P2Block");

        // if stood still
        if(P2vertical == 0 && P2horizontal == 0)
        {
            anima.SetInteger("condition", 0);
        }
        // else handle directional animation
        else
        {
            if (P2vertical > 0)
            {
                anima.SetInteger("condition", 1);
            }
            else if (P2vertical < 0)
            {
                anima.SetInteger("condition", 2);
            }

            if (P2horizontal > 0)
            {
                anima.SetInteger("condition", 4);
            }
            else if (P2horizontal < 0)
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
 
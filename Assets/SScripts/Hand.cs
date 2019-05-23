using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {


    private float x = 0;
    public Damage damageScript;
    private void OnTriggerEnter(Collider other)
    {
        //If current object isn't a parent of the collided object, get if that specific hand can attack or not and perform an attack
        if (!transform.IsChildOf(other.transform))
        {
            // determine if currently blocking
            Controller player = gameObject.GetComponentInParent<Controller>();
            if (!player.Blocking())
            {
                if (name == "RightHand")
                {
                    x = transform.root.gameObject.GetComponent<IKControl>().rHand;
                }
                else
                {
                    x = transform.root.gameObject.GetComponent<IKControl>().lHand;
                }

                if (x > 0 && other.tag == "Player")
                {
                    damageScript.Attack();
                }
            }
        }
    }
}

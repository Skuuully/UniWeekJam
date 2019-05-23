using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class DamageText : MonoBehaviour {
    //publics
    

    //privates
    TextMeshPro text;
    GameObject[] players;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<TextMeshPro>();
        players = GameObject.FindGameObjectsWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        string p1text;
        string p2text;
        if(players[0].GetComponentInParent<Controller>().P1)
        {
            p1text = players[0].GetComponent<Damage>().damageDealt.ToString();
            p2text = players[1].GetComponent<Damage>().damageDealt.ToString();
        }
        else
        {
            p2text = players[0].GetComponent<Damage>().damageDealt.ToString();
            p1text = players[1].GetComponent<Damage>().damageDealt.ToString();
        }

        text.SetText(p1text +" : " + p2text);
    }
}

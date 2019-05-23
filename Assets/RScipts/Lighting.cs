using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class Lighting : MonoBehaviour {

    //publics
    public Color baseColor;
    public Color damageColor;
    public bool LookAtP1;
    public bool LookAtP2;
    public Vector3 defaultPosition;

    //privates
    Light _light;
    Beats beats;
    GameObject[] players;    

    // Use this for initialization
    void Start ()
    {
        _light = GetComponent<Light>();
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        // set the color to the corresponding dmg/ no dmg
        Color lightColor = DetermineColor();
        _light.color = lightColor;

        if (LookAtP1)
        {
            LookAtPosition(players[0].transform.position);
        }
        else if (LookAtP2)
        {
            LookAtPosition(players[1].transform.position);
        }
    }

    // get if its damage time from the stereo
    Color DetermineColor()
    {
        if(!beats.DamageTime())
        {
            return baseColor;
        }
        return damageColor;
    }

    void LookAtPosition(Vector3 position)
    {
        transform.LookAt(position);
    }
}

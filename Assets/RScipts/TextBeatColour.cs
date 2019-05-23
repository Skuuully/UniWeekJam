using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBeatColour : MonoBehaviour {

    //publics
    public Color baseColor;
    public Color damageColor;

    //privates
    TextMeshPro text;
    Beats beats;

    // Use this for initialization
    void Start ()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Color textColor = DetermineColor();
        text.color = textColor;
	}

    Color DetermineColor()
    {
        if (!beats.DamageTime())
        {
            return baseColor;
        }
        return damageColor;
    }
}

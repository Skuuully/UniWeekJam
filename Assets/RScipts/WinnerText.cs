using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerText : MonoBehaviour {

    TextMeshProUGUI text;
    GameObject[] players;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        string p1text = "";
        string p2text = "";
        if (players[0].GetComponentInParent<Controller>().P1)
        {
            p1text = players[0].GetComponent<Damage>().damageDealt.ToString();
            p2text = players[1].GetComponent<Damage>().damageDealt.ToString();
        }
        else
        {
            p1text = players[1].GetComponent<Damage>().damageDealt.ToString();
            p2text = players[0].GetComponent<Damage>().damageDealt.ToString();
        }

        float p1dmg = float.Parse(p1text);
        float p2dmg = float.Parse(p2text);
        string winTxt = "";

        if (p1dmg == p2dmg)
        {
            winTxt = "Draw!";
        }
        else if (p1dmg > p2dmg)
        {
            winTxt = "Player 1 Wins!";
        }
        else
        {
            winTxt = "Player 2 Wins!";
        }

        text.SetText(winTxt);

    }
}

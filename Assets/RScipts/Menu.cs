using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    //publics
    public Button button;
    //privates
    Beats beats;
    GameObject[] players;
    
	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
        button.onClick.AddListener(buttonClick);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(beats.SongPlaying())
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }

    void buttonClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        /*beats.PlaySong();
        for(int i = 0; i <players.Length; i++)
        {
            players[i].GetComponent<Damage>().ResetDamage();
        } */
    }
}

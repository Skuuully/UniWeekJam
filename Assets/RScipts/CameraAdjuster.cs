using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour {

    //public
    public float minRotation;
    public float maxRotation;
    public Vector3 offset;
    public float lerpStrength;
    Beats beats;

    //private
    GameObject[] players;

    // Use this for initialization
    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 camShake = CameraShake();
        Vector3 currentPos = transform.position - camShake;
        Vector3 newPos = CalculateAveragePosition(currentPos.y);

        transform.position += camShake;


        transform.position = Vector3.Lerp(currentPos, newPos, lerpStrength);
    }

    // gets the average position between the players
    Vector3 CalculateAveragePosition(float camYPos)
    {
        int numOfPlayers = players.Length;
        Vector3 averagePosition = new Vector3(0.0f, 0.0f, 0.0f);

        // foreach player add to averageposition and setup y's
        for (int i = 0; i < numOfPlayers; i++)
        {
            Vector3 playerPosition = new Vector3(players[i].transform.position.x, players[i].transform.position.y, players[i].transform.position.z);
            averagePosition += playerPosition;
        }

        // set camera position
        averagePosition = averagePosition / numOfPlayers;
        Vector3 newPosition = new Vector3(averagePosition.x + offset.x, camYPos, averagePosition.z + offset.z);
        return newPosition;
    }


    // found online, just gets a value in a range ito a new one
    float ConvertRange(
        float originalStart, float originalEnd, // original range
        float newStart, float newEnd, // desired range
        float value) // value to convert
    {
        float scale = (newEnd - newStart) / (originalEnd - originalStart);
        return newStart + ((value - originalStart) * scale);
    }

    Vector3 CameraShake()
    {
        if (beats.DamageTime())
        {
            float shakeAmount = 0.15f;
            Vector3 v = new Vector3((Random.insideUnitSphere * shakeAmount).x, 0.0f, (Random.insideUnitSphere * shakeAmount).z);
            return v;
        }
        Vector3 zeroVector = new Vector3(0.0f, 0.0f, 0.0f);
        return zeroVector;
    } 
}


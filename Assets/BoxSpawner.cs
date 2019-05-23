using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

    public int numberToSpawn;
    public float spawnIncrement;
    public GameObject explodyBoomBox;
    public float heightToSpawn;
    private float xPosToSpawn;
    private float yPosToSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnBox", 0, spawnIncrement);
    }

    private void SpawnBox()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            xPosToSpawn = Random.Range(-4f, 4f);
            yPosToSpawn = Random.Range(-4f, 4f);
            Vector3 posToSpawn = new Vector3(xPosToSpawn, heightToSpawn, yPosToSpawn);
            Instantiate(explodyBoomBox, posToSpawn, explodyBoomBox.transform.rotation);
        }

    }

}

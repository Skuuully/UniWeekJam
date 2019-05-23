using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAfterTime : MonoBehaviour {

    public GameObject explosionParticles;
    public float explodeTime;
    private void Start()
    {
        if (explodeTime < 2)
        {
            explodeTime = 2;
        }
        explodeTime = Random.Range(explodeTime - 2, explodeTime + 2);
        Invoke("Explode", explodeTime);
    }

    void Explode()
    {
        if (explosionParticles != null)
        {
            Vector3 spawnPos = transform.position;
            Instantiate(explosionParticles, spawnPos, transform.rotation);
        }
        Destroy(gameObject);
    }

}

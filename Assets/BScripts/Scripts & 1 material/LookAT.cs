using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAT : MonoBehaviour {

    public Transform target;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);

        Vector3 vectorRotation = newRotation.eulerAngles;
        vectorRotation.x = 0.0f; // remove x rotation so that they cannot run upwards

        transform.rotation = Quaternion.Euler(vectorRotation);
    }
}

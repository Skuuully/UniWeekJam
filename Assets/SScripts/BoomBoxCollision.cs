using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoxCollision : MonoBehaviour {

    private BoomBox boomBox;
    private Vector3 otherPosition;

    private void Start()
    {
        boomBox = GetComponentInParent<BoomBox>();
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.tag == "OOB")
        {
            boomBox.transform.position = new Vector3(1, 10, 1);
        }*/

        if (other.tag == "Player")
        {
            otherPosition = other.gameObject.transform.position;
            otherPosition.y = 0;
            Vector3 directionAwayFromPlayer = transform.position - otherPosition;
            directionAwayFromPlayer.Normalize();
            directionAwayFromPlayer *= 30;
            boomBox.rb.AddForce(directionAwayFromPlayer, ForceMode.Impulse);
        }

    }
}

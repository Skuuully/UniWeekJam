using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoomBox : MonoBehaviour {

    private Beats beats;
    public Rigidbody rb;
    private MeshRenderer meshRenderer;
    public float force = 20;
    private float zoffset;
    private float xoffset;
    private bool beatOffset;
    private int colorToUse;
    private Color color;

    float ytorque;
    float ztorque;
    float xtorque;

    private bool jump = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        beats = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<Beats>();
        meshRenderer = GetComponent<MeshRenderer>();
        beatOffset = Random.value > 0.5f;
	}




        // Update is called once per frame
        void FixedUpdate () {
		if (beats.DamageTime())
        {
            if (jump)
            {
                jump = false;
                colorToUse = Random.Range(0, 6);
                switch (colorToUse)
                {
                    case 0:
                        color = Color.red;
                        break;
                    case 1:
                        color = Color.green;
                        break;
                    case 2:
                        color = Color.blue;
                        break;
                    case 3:
                        color = Color.cyan;
                        break;
                    case 4:
                        color = Color.clear;
                        break;
                    case 5:
                        color = Color.grey;
                        break;
                    default:
                        break;
                }
                color = color * 0.5f;

                meshRenderer.material.color = color;

                xoffset = Random.Range(-5.0f, 5.0f);
                zoffset = Random.Range(-5.0f, 5.0f);
                xtorque = Random.Range(-1.0f, 1.0f);
                ytorque = Random.Range(-1.0f, 1.0f);

                if (beatOffset)
                {
                    beatOffset = false;


                    if (transform.rotation.z < 0)
                    {
                        ztorque = 80;
                    }
                    else if (transform.rotation.z > -0)
                    {
                        ztorque = -80;
                    }

                    if (transform.rotation.x < 0)
                    {
                        xtorque = 80;
                    }
                    else if (transform.rotation.x > -0)
                    {
                        xtorque = -80;
                    }
                    rb.AddForce(new Vector3(xoffset, force, zoffset), ForceMode.Impulse);
                    rb.AddTorque(new Vector3(xtorque, ytorque, ztorque), ForceMode.Impulse);
                }
                else
                {
                    beatOffset = true;
                    ztorque = 0;
                    xtorque = 0;

                    rb.AddForce(new Vector3(xoffset, force, zoffset), ForceMode.Impulse);
                    rb.AddRelativeTorque(new Vector3(xtorque, ytorque, ztorque), ForceMode.Impulse);
                }
            }
        }
        else
        {
            jump = true;
            rb.AddForce(new Vector3(0, -force / 2 , 0), ForceMode.Impulse);
        }

	}
}

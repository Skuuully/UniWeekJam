using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    private Vector3 inputVector;
    private float inputX;
    private float inputZ;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
       inputVector = new Vector3(Input.GetAxisRaw("Horizontal") *10f , playerBody.velocity.y, Input.GetAxisRaw("Vertical")* 10f);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
    }
    private void FixedUpdate()
    {
playerBody.velocity = inputVector;
    }
}

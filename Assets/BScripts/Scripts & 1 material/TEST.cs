using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    public bool P1;
    public float Speed;
    public float rotSpeed;
    float rot;
    float rot2;



    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rot = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        float gravity = 9.81f;


        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= Speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("condition", 2);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= Speed - 5;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.E))
            {
                anim.SetInteger("condition", 4);
                moveDir = new Vector3(1, 0, 0);
                moveDir *= Speed - 10;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                anim.SetInteger("condition", 3);
                moveDir = new Vector3(-1, 0, 0);
                moveDir *= Speed - 10;
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);


    }
}
   

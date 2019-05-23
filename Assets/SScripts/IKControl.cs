using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{
    public bool p1;
    public GameManager gameManager;
    public float lHand = 0;
    public Transform punchObj = null;
    public Transform lookObj = null;
    public float rHand = 0;

    private Transform leftShoulder;
    private Transform rightShoulder;
    protected Animator animator;
    private bool punching = false;
    private bool useRightHand = false;
    

    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "LeftShoulder")
            {
                leftShoulder = child;
            }
            else if (child.name == "RightShoulder")
            {
                rightShoulder = child;
            }
        }

        animator = GetComponent<Animator>();


    }


    private void FixedUpdate()
    {
        if (p1)
        {
            punching = gameManager.p1punch;
        }

        if (!p1)
        {
            punching = gameManager.p2punch;
        }
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
                // Set the look target position, if one has been assigned
            if (lookObj != null)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(lookObj.position);
            }

                // Set the target position and rotation, if one has been assigned
            if (punchObj != null)
            {
                if (punching == true)
                {
                    float rHandDist = Vector3.Distance(rightShoulder.position, punchObj.position);
                    float lHandDist = Vector3.Distance(leftShoulder.position, punchObj.position);

                    if (rHandDist <= lHandDist)
                    {
                        useRightHand = true;
                    }
                    else
                    {
                        useRightHand = false;
                    }

                    if (useRightHand == true)
                    {
                        
                        rHand = 1;
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rHand);
                        //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rHand);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, punchObj.position);
                        //animator.SetIKRotation(AvatarIKGoal.RightHand, punchObj.rotation);
                    }
                    else
                    {
                        lHand = 1;
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, lHand);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, lHand);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, punchObj.position);
                        //animator.SetIKRotation(AvatarIKGoal.LeftHand, punchObj.rotation);
                    }

                    if (p1)
                    {
                        gameManager.p1punch = false;
                    }

                    if (!p1)
                    {
                        gameManager.p2punch = false;
                    }
                }

                if (rHand > 0.0f)
                {
                    rHand -= 0.05f;
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rHand);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rHand);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, punchObj.position);
                    //animator.SetIKRotation(AvatarIKGoal.RightHand, punchObj.rotation);
                }
                else
                {
                    rHand = 0;
                }

                if (lHand > 0.0f)
                {
                    lHand -= 0.05f;
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, lHand);
                    //animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, lHand);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, punchObj.position);
                    //animator.SetIKRotation(AvatarIKGoal.LeftHand, punchObj.rotation);
                   // Debug.Log(lHand);
                }
                else
                {
                    lHand = 0;
                }
            }
        }
    }
}
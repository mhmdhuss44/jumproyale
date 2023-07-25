using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drAnimator : MonoBehaviour
{
    Animator mhmd;
    PhotonView view;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Store the previous position of the player
    Vector3 previousPosition;

    void Start()
    {
        mhmd = transform.GetChild(2).GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        // Initialize the previous position
        previousPosition = transform.position;
    }

    void Update()
    {
        if (view.IsMine)
        {
            // Get the current position of the player
            Vector3 currentPosition = transform.position;

            // Check if the z or x values have changed
            if (currentPosition.z != previousPosition.z || currentPosition.x != previousPosition.x)
            {
                mhmd.SetBool("iswalking", true);
            }
            else
            {
                mhmd.SetBool("iswalking", false);
            }

            // Update the previous position for the next frame
            previousPosition = currentPosition;

            bool var = isGrounded();
            mhmd.SetBool("jump", !var);
        }
    }

    private bool IsCollidingWithGroundOrEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Ground"))
            {
                return true;
            }
        }

        return false;
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}

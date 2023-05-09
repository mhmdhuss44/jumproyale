using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foranime : MonoBehaviour
{

    Animator mhmd;
    PhotonView view;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        mhmd = transform.GetChild(3).GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                mhmd.SetBool("iswalking", true);
            }
            else
            {
                mhmd.SetBool("iswalking", false);
            }
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



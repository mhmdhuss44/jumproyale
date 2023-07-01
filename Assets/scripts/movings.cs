using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class movings : MonoBehaviour
{
    Rigidbody posRb;
    [SerializeField] float moves = 5f;
    [SerializeField] float jumpforce = 5f;
    float lastJumpTime = -2f;
    [SerializeField] Transform groundCkeck;
    [SerializeField] LayerMask Ground;

    PhotonView view;

    void Start()
    {
        posRb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();

    }

    void Update()
    {
        if (view.IsMine)
        {
            posRb.velocity = new Vector3(posRb.velocity.x * moves, posRb.velocity.y, posRb.velocity.z * moves);

            if (IsOnGround() && Time.time - lastJumpTime > 2)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        posRb.velocity = new Vector3(posRb.velocity.x, jumpforce, posRb.velocity.z);
        lastJumpTime = Time.time;
    }

    bool IsOnGround()
    {
        return Physics.CheckSphere(groundCkeck.position, 0.1f, Ground);
    }
}

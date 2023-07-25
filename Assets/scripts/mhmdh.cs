using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class mhmdh : MonoBehaviourPunCallbacks
{
    Rigidbody posRb;
    [SerializeField] float moves = 3f;
    [SerializeField] float jumpforce = 7f;
    float lastJumpTime = -3f;
    [SerializeField] Transform groundCkeck;
    [SerializeField] LayerMask Ground;
    [SerializeField] float searchRadius = 10f; // Radius to search for players
    [SerializeField] string playerTag = "newplayer"; // Tag of the players
    [SerializeField] float walkDistance = 5.0f;

    bool isJumping = false;
    float jumpStartTime = 0f;
    float jumpDuration = 1f;

    void Start()
    {
        posRb = GetComponent<Rigidbody>();

        if (photonView.IsMine)
        {
            // This is the local player's object
        }
        else
        {
            // This is a remote player's object, disable unnecessary components
            posRb.isKinematic = true;
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        // Locate the nearest player with the specified tag
        Transform nearestPlayer = FindNearestPlayerWithTag(playerTag);

        // Calculate the direction to the nearest player
        Vector3 targetDirection = Vector3.zero;
        if (nearestPlayer != null)
        {
            targetDirection = nearestPlayer.position - transform.position;
            targetDirection.y = 0f; // Ignore vertical distance
            targetDirection.Normalize();
        }

        // Rotate the player to face the target direction
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        float moveSpeed = 0f;
        float distanceToPlayer = nearestPlayer != null ? Vector3.Distance(transform.position, nearestPlayer.position) : float.MaxValue;

        if (distanceToPlayer > walkDistance)
        {
            // Player is far, walk towards the player
            moveSpeed = moves;
        }
        else
        {
            // Player is close, jump towards the player
            moveSpeed = moves;
            if (nearestPlayer != null && IsOnGround() && Time.time - lastJumpTime > 3)
            {
                photonView.RPC("Jump", RpcTarget.All); // Call the Jump() method across the network
            }
        }

        if (nearestPlayer != null)
        {
            posRb.velocity = new Vector3(targetDirection.x * moveSpeed, posRb.velocity.y, targetDirection.z * moveSpeed);
        }
    }

    [PunRPC]
    void Jump()
    {
        if (photonView.IsMine)
        {
            posRb.velocity = new Vector3(posRb.velocity.x, jumpforce, posRb.velocity.z);
            lastJumpTime = Time.time;
            isJumping = true;
            jumpStartTime = Time.time;
        }
    }

    bool IsOnGround()
    {
        return Physics.CheckSphere(groundCkeck.position, 0.1f, Ground);
    }

    Transform FindNearestPlayerWithTag(string tag)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(tag);
        Transform nearestPlayer = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < shortestDistance && distance <= searchRadius)
            {
                shortestDistance = distance;
                nearestPlayer = player.transform;
            }
        }

        return nearestPlayer;
    }
}

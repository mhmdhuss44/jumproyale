using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMoves : MonoBehaviour
{
   Rigidbody posRb;
    [SerializeField] float moves = 5f;
    [SerializeField] float jumpforce = 5f;
    float lastJumpTime = -2f;
    float lastAttackTime = -2f;
    [SerializeField] Transform groundCkeck;
    [SerializeField] LayerMask Ground;
    public Transform cameraTransform;
    private float pitch = 0f;
    float sense = 3f;
    float MinPitch = -45f;
    float MaxPitch = 45f;

    PhotonView view;

    void Start()
    {
        posRb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            cameraTransform.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horiz, 0, vert);
            moveDirection = transform.rotation * moveDirection;
            posRb.velocity = new Vector3(moveDirection.x * moves, posRb.velocity.y, moveDirection.z * moves);

            if (Input.GetButtonDown("Jump") && onEarth() && Time.time - lastJumpTime > 2)
            {
                posRb.velocity = new Vector3(posRb.velocity.x, jumpforce, posRb.velocity.z);
                lastJumpTime = Time.time;
            }

            changelook();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy Head"))
    //    {
    //        PlayersHealth enemyHealth = collision.gameObject.GetComponentInParent<PlayersHealth>();

    //        if (enemyHealth != null)
    //        {
    //            enemyHealth.TakeDamage(1);

    //            if (enemyHealth.currentHealth > 0)
    //            {
    //                // If the enemy is still alive, jump and move the player backward
    //                jumpAndmove();
    //                transform.Translate(Vector3.back * 2f);
    //                lastAttackTime = Time.time;
    //            }
    //            else
    //            {
    //                lastJumpTime = Time.time;
    //            }
    //        }
    //    }
    //}

    bool onEarth()
    {
        return Physics.CheckSphere(groundCkeck.position, 0.1f, Ground);
    }




    //void jumpAndmove()
    //{
    //    // Wait for 2 seconds before allowing the player to jump again after attacking an enemy
    //    if (Time.time - lastAttackTime < 2)
    //    {
    //        return;
    //    }

    //    // jump and move back a little bit
    //    Vector3 movement = -transform.forward * moves * 1.5f + Vector3.up * jumpforce;

    //    // Apply the movement vector to the player's rigidbody
    //    posRb.velocity = movement;

    //    // Move the player's position by a small amount to visually show the movement
    //    transform.position += transform.forward * -2f;
    //}
    void changelook()
    {
        float mouseInput = Input.GetAxis("Mouse X") * sense;
        transform.Rotate(0, mouseInput, 0);
        pitch -= Input.GetAxis("Mouse Y") * sense;
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

 
}
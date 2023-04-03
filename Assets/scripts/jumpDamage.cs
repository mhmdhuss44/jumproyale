using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class jumpDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float moves = 5f;
    [SerializeField] private float jumpforce = 5f;
    private float lastJumpTime = -2f;
    private float lastAttackTime = -2f;
    private Rigidbody posRb;

    private void Start()
    {
        posRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy Head")) // assuming you tagged the player's head collider as "PlayerHead"
        {
            PlayersHealth enemyHealth = collision.collider.transform.parent.parent.GetComponent<PlayersHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                if (enemyHealth.currentHealth > 0)
                {
                    // If the enemy is still alive, jump and move the player backward
                    jumpAndMove();
                    transform.Translate(Vector3.back * 2f);
                    lastAttackTime = Time.time;
                }
                else
                {
                    lastJumpTime = Time.time;
                }
            }
        }
    }

    private bool onGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1.1f);
    }

    private void jumpAndMove()
    {
        // Wait for 2 seconds before allowing the player to jump again after attacking an enemy
        if (Time.time - lastAttackTime < 2)
        {
            return;
        }

        // Jump and move back a little bit
        Vector3 movement = -transform.forward * moves * 1.5f + Vector3.up * jumpforce;

        // Apply the movement vector to the player's rigidbody
        posRb.velocity = movement;

        // Move the player's position by a small amount to visually show the movement
        transform.position += transform.forward * -2f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modzonedamage : MonoBehaviour
{
    private bool playerInPlane = false;
    private GameObject currentPlayer; // Reference to the current player inside the zone
    private float timeSinceLastDamage = 0f;
    private float damageInterval = 10f;
    private int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("newplayer"))
        {
            playerInPlane = true;
            currentPlayer = other.gameObject; // Set the current player to the one that entered the zone
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("newplayer"))
        {
            playerInPlane = false;
            currentPlayer = null; // Reset the current player reference when the player exits the zone
            timeSinceLastDamage = 0f;
        }
    }

    private void Update()
    {
        if (playerInPlane && currentPlayer != null)
        {
            timeSinceLastDamage += Time.deltaTime;
            if (timeSinceLastDamage >= damageInterval)
            {
                timeSinceLastDamage = 0f;

                DangerZoneCounter dangerZoneCounter = currentPlayer.GetComponent<DangerZoneCounter>();

                if (dangerZoneCounter != null && dangerZoneCounter.GetDangerZoneCount() < 4)
                {
                    PlayersHealth playerHealth = currentPlayer.GetComponent<PlayersHealth>();

                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damageAmount);
                    }
                }
            }
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class modzonedamage : MonoBehaviour
//{
//    private bool playerInPlane = false;
//    private GameObject currentPlayer; // Reference to the current player inside the zone
//    private float timeSinceLastDamage = 0f;
//    private float damageInterval = 5f;
//    private int damageAmount = 1;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("newplayer"))
//        {
//            playerInPlane = true;
//            currentPlayer = other.gameObject; // Set the current player to the one that entered the zone
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("newplayer"))
//        {
//            playerInPlane = false;
//            currentPlayer = null; // Reset the current player reference when the player exits the zone
//            timeSinceLastDamage = 0f;
//        }
//    }

//    private void Update()
//    {
//        if (playerInPlane && currentPlayer != null)
//        {
//            timeSinceLastDamage += Time.deltaTime;
//            if (timeSinceLastDamage >= damageInterval)
//            {
//                timeSinceLastDamage = 0f;

//                DangerZoneCounter dangerZoneCounter = currentPlayer.GetComponent<DangerZoneCounter>();

//                if (dangerZoneCounter != null && dangerZoneCounter.GetDangerZoneCount() < 4)
//                {
//                    PlayersHealth playerHealth = currentPlayer.GetComponent<PlayersHealth>();

//                    if (playerHealth != null)
//                    {
//                        playerHealth.TakeDamage(damageAmount);
//                    }
//                }
//            }
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modzonedamage : MonoBehaviour
{
    private Dictionary<GameObject, float> playersInZone = new Dictionary<GameObject, float>(); // Dictionary to store players inside the zone and their time since last damage
    private float damageInterval = 5f;
    private int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("newplayer") || other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            if (!playersInZone.ContainsKey(player))
            {
                playersInZone.Add(player, 0f); // Initialize the time since last damage to 0 for the new player
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("newplayer") || other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            if (playersInZone.ContainsKey(player))
            {
                playersInZone.Remove(player);
            }
        }
    }

    private void Update()
    {
        // Loop through the players inside the zone
        foreach (GameObject player in new List<GameObject>(playersInZone.Keys))
        {
            if (player == null)
            {
                playersInZone.Remove(player); // Remove the player if it no longer exists (e.g., was destroyed)
                continue;
            }

            DangerZoneCounter dangerZoneCounter = player.GetComponent<DangerZoneCounter>();
            if (dangerZoneCounter != null && dangerZoneCounter.GetDangerZoneCount() >= 4)
            {
                continue; // Skip this player if they already have 4 danger zones
            }

            // Increment the time since last damage for the player
            playersInZone[player] += Time.deltaTime;

            // Check if the player should take damage
            if (playersInZone[player] >= damageInterval)
            {
                playersInZone[player] = 0f; // Reset the time since last damage

                // Check the tag of the player and call the appropriate health script
                if (player.CompareTag("newplayer"))
                {
                    PlayersHealth playerHealth = player.GetComponent<PlayersHealth>();
                    if (playerHealth != null)
                    {
                        // Apply damage to the 'newplayer'
                        playerHealth.TakeDamage(damageAmount);
                    }
                }
                else if (player.CompareTag("Player"))
                {
                    CloneHealth cloneHealth = player.GetComponent<CloneHealth>();
                    if (cloneHealth != null)
                    {
                        // Apply damage to the 'Player'
                        cloneHealth.TakeDamage(damageAmount);
                    }
                }
            }
        }
    }
}



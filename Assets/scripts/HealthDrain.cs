using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrain : MonoBehaviour
{
    private bool playerInPlane = false;
    private float timeSinceLastDamage = 0f;
    private float damageInterval = 10f;
    private int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("newplayer"))
        {
            playerInPlane = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("newplayer"))
        {
            playerInPlane = false;
            timeSinceLastDamage = 0f;
        }
    }

    private void Update()
    {
        if (playerInPlane)
        {
            timeSinceLastDamage += Time.deltaTime;
            if (timeSinceLastDamage >= damageInterval)
            {
                timeSinceLastDamage = 0f;
                GameObject player = GameObject.FindGameObjectWithTag("newplayer");
                player.GetComponent<PlayersHealth>().TakeDamage(damageAmount);
            }
        }
    }
}
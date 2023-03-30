using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decHealth : MonoBehaviour
{
    private int damagePerSecond = 2;
    private PlayersHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<PlayersHealth>();
            StartCoroutine(DealDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            playerHealth.TakeDamage(damagePerSecond);
        }
    }
}
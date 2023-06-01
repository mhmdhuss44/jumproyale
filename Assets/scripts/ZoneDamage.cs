using UnityEngine;
using Photon.Pun;

public class ZoneDamage : MonoBehaviour
{
    private PlayersHealth playerHealth;
    private bool isInsideZone = false;
    private float damageInterval = 20f;
    private float timer = 0f;
    private float damageAmount = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayersHealth>();
            isInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideZone = false;
        }
    }

    private void Update()
    {
        if (isInsideZone)
        {
            timer += Time.deltaTime;
            if (timer >= damageInterval)
            {
                playerHealth.TakeDamage(damageAmount);
                timer = 0f;
            }
        }
    }
}

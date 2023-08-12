using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealth : MonoBehaviourPun
{
    [SerializeField] private int maxHealth = 2;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            TakeDamage(2); // Call TakeDamage function with a value of 2
        }
    }

    public void TakeDamage(int damage)
    {
        if (!photonView.IsMine)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            photonView.RPC("Die", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Die()
    {
        // Destroy the enemy object when it runs out of health, but only on the owning client
        if (photonView.IsMine)
            PhotonNetwork.Destroy(gameObject);
    }
}


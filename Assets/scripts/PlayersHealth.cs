using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealth : MonoBehaviourPunCallbacks
{
    [SerializeField] private int maxHealth = 2;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            photonView.RPC("Die", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Die()
    {
        // Destroy the player object across all the games
        PhotonNetwork.Destroy(transform.parent.gameObject);
    }
}
using UnityEngine;
using Photon.Pun;

public class PlayersHealth : MonoBehaviourPun
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
            PhotonView pv = GetComponent<PhotonView>();
            pv.RPC("Die", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Die()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            // Destroy the player object when it runs out of health
            PhotonNetwork.Destroy(gameObject);
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayersHealth : MonoBehaviour
//{
//    [SerializeField] private int maxHealth = 2;
//    public int currentHealth;

//    private void Start()
//    {
//        currentHealth = maxHealth;
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    private void Die()
//    {
//        // Destroy the enemy object when it runs out of health
//        Destroy(transform.parent.gameObject);
//    }
//}
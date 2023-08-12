using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayersHealth : MonoBehaviourPun
{
    [SerializeField] private int maxHealth = 2;
    public float currentHealth;

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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            PhotonView pv = GetComponent<PhotonView>();
            pv.RPC("Die", RpcTarget.AllBuffered, pv.ViewID);
        }
    }

    [PunRPC]
    private void Die(int viewID)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == viewID / 1000)
        {
            // Destroy the player object when it runs out of health
            PhotonNetwork.Destroy(gameObject);
            // Transition to the "Lost" scene
            SceneManager.LoadScene("lost");
        }
    }
}

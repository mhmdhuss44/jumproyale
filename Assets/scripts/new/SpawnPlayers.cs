using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    public float minx;
    public float minz;
    public float maxx;
    public float maxz;
    public float yval;

    void Start()
    {
        // Spawn player
        Vector3 randomPosition = new Vector3(Random.Range(minx, maxx), yval, Random.Range(minz, maxz));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minx;
    public float minz;
    public float maxx;
    public float maxz;
    public float yval;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(minx, maxx), yval, Random.Range(minz, maxz));
            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        }
    }
}

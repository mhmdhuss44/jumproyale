using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CubeScaler : MonoBehaviourPun, IPunObservable
{
    public float growthRate = 0.1f;
    public float maxXSize = 80;
    public float maxZSize = 80;

    private Vector3 targetScale;

    private void Start()
    {
        targetScale = transform.localScale;
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        // Increase the scale gradually over time
        targetScale.x = Mathf.Clamp(targetScale.x + growthRate * Time.deltaTime, 0f, maxXSize);
        targetScale.z = Mathf.Clamp(targetScale.z + growthRate * Time.deltaTime, 0f, maxZSize);

        // Apply the new scale to the cube
        photonView.RPC("ScaleCube", RpcTarget.AllBuffered, targetScale);
    }

    [PunRPC]
    private void ScaleCube(Vector3 newScale)
    {
        transform.localScale = newScale;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the scale over the network
            stream.SendNext(targetScale);
        }
        else if (stream.IsReading)
        {
            // Receive the scale from the network
            targetScale = (Vector3)stream.ReceiveNext();
        }
    }
}

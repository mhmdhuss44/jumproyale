using UnityEngine;
using Photon.Pun;

public class zliner : MonoBehaviourPun, IPunObservable
{
    public float targetX = 25f;  // The target x position
    public float speed = 1f;     // The speed at which the object moves

    private float currentX;      // The current x position

    private void Start()
    {
        currentX = transform.position.z;  // Initialize the current x position

        if (!photonView.IsMine)
        {
            // Disable the script for non-local players
            enabled = false;
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (currentX < targetX)
            {
                // Calculate the new x position based on the speed and time
                float newX = currentX + speed * Time.deltaTime;

                // Clamp the new x position to ensure it doesn't exceed the target
                newX = Mathf.Clamp(newX, currentX, targetX);

                // Update the object's position
                transform.position = new Vector3(transform.position.x, transform.position.y, newX);

                // Update the current x position
                currentX = newX;

                // Synchronize the position across the network
                photonView.RPC("SyncPosition", RpcTarget.OthersBuffered, newX);
            }
        }
    }

    // RPC method to synchronize the position across the network
    [PunRPC]
    private void SyncPosition(float newX)
    {
        currentX = newX;
        transform.position = new Vector3(transform.position.x, transform.position.y, newX);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the currentX value to other players
            stream.SendNext(currentX);
        }
        else if (stream.IsReading)
        {
            // Receive the currentX value from the owner player and update it
            currentX = (float)stream.ReceiveNext();
        }
    }
}

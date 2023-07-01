using UnityEngine;
using Photon.Pun;

public class linemovetwo : MonoBehaviourPun, IPunObservable
{
    public float targetX = 25f;       // The target x position
    public float minTargetX = 10f;    // The minimum x position
    public float speed = 1f;          // The speed at which the object moves

    private float currentX;           // The current x position
    private bool isMoving = false;    // Flag to control movement

    private void Start()
    {
        currentX = transform.position.x;  // Initialize the current x position

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
            if (isMoving && currentX > minTargetX)
            {
                // Calculate the new x position based on the speed and time
                float newX = currentX - speed * Time.deltaTime;

                // Clamp the new x position to ensure it doesn't go below the minimum target
                newX = Mathf.Clamp(newX, minTargetX, currentX);

                // Update the object's position
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);

                // Update the current x position
                currentX = newX;

                // Synchronize the position across the network
                photonView.RPC("SyncPosition", RpcTarget.OthersBuffered, newX, isMoving);
            }
        }
    }

    // RPC method to synchronize the position and isMoving flag across the network
    [PunRPC]
    private void SyncPosition(float newX, bool newIsMoving)
    {
        currentX = newX;
        isMoving = newIsMoving;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the currentX and isMoving values to other players
            stream.SendNext(currentX);
            stream.SendNext(isMoving);
        }
        else if (stream.IsReading)
        {
            // Receive the currentX and isMoving values from the owner player and update them
            currentX = (float)stream.ReceiveNext();
            isMoving = (bool)stream.ReceiveNext();
        }
    }

    // Method to start moving
    public void StartMoving()
    {
        isMoving = true;
    }

    public void SetFalse()
    {
        isMoving = false;
    }
}

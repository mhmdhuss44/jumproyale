using UnityEngine;

public class jumpbot : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer; // The player to jump towards
    [SerializeField] private float jumpForce = 5f; // The force applied to the jump

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (targetPlayer == null)
        {
            Debug.LogWarning("Target player not assigned!");
            return;
        }

        // Calculate the distance between the two players
        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        // Check if the distance is below a certain threshold to initiate the jump
        if (distance < 10f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Calculate the direction from the player to the target
        Vector3 direction = (targetPlayer.position - transform.position).normalized;

        // Apply a jump force in the calculated direction
        rb.AddForce(direction * jumpForce, ForceMode.Impulse);
    }
}

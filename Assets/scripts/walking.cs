using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    Rigidbody posRb;
    [SerializeField] float moves = 3f;
    [SerializeField] Transform target; // Your target position

    void Start()
    {
        posRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the direction to the target position
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0f; // Ignore vertical distance
        targetDirection.Normalize();

        // Rotate the player to face the target direction
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Move the player towards the target position
        posRb.velocity = new Vector3(targetDirection.x * moves, posRb.velocity.y, targetDirection.z * moves);
    }
}

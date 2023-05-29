using UnityEngine;

public class zliner : MonoBehaviour
{
    public float targetX = 25f;  // The target x position
    public float speed = 1f;     // The speed at which the object moves

    private float currentX;      // The current x position

    private void Start()
    {
        currentX = transform.position.z;  // Initialize the current x position
    }

    private void Update()
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
        }
    }
}

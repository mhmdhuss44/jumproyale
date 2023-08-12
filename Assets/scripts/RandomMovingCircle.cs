using System.Collections;
using UnityEngine;

public class RandomMovingCircle : MonoBehaviour
{
    public float minInterval = 20f;
    public float maxInterval = 20f;
    public float boundaryY = 108.83f;
    public float minZ = -230f; // Minimum Z position
    public float maxZ = -220f; // Maximum Z position
    public float minX = 110f; // Minimum X position
    public float maxX = 118f; // Maximum X position

    public bool isMiddleSeconds = false; // Flag for middle 10 seconds

    private void Start()
    {
        StartCoroutine(MoveCircle());
    }

    private IEnumerator MoveCircle()
    {
        while (true)
        {
            // Calculate a random position within the specified boundaries
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            Vector3 targetPosition = new Vector3(randomX, boundaryY, randomZ);

            // Move the circle to the target position instantly
            transform.position = targetPosition;

            // Set the flag to true for the middle 10 seconds
            isMiddleSeconds = true;

            // Wait for a random interval before moving again
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(15f); // Subtract 10 seconds

            isMiddleSeconds = false; // Reset the flag

            // Wait for the remaining 10 seconds
            yield return new WaitForSeconds(5f);
        }
    }
}

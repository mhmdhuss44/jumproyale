using System.Collections;
using UnityEngine;

public class RocketDropper : MonoBehaviour
{
    public GameObject firePrefab; // Assign the fire prefab in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        InstantiateFireAndDestroyRocket();
    }

    private IEnumerator DestroyRocketWithDelay(GameObject rocket)
    {
        yield return new WaitForSeconds(0.1f); // Wait for some time
        Destroy(rocket); // Destroy the rocket after the delay
    }

    private IEnumerator DestroyFireWithDelay(GameObject fire)
    {
        yield return new WaitForSeconds(0.7f); // Wait for one second
        Destroy(fire); // Destroy the fire after one second
    }

    private void InstantiateFireAndDestroyRocket()
    {
        // Instantiate fire at the rocket's position
        GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
        // Start coroutine to destroy the rocket after a short delay
        StartCoroutine(DestroyRocketWithDelay(gameObject));

        // Start coroutine to destroy the fire after one second
        StartCoroutine(DestroyFireWithDelay(fire));


    }
}

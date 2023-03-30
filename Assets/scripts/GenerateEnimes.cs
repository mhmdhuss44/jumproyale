using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnimes : MonoBehaviour
{// Declaring public variables
    public GameObject theEnemy; // A reference to the enemy object that we want to create
    public int eneCreated; // A counter variable to keep track of the number of enemies created

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine that will create the enemies
        StartCoroutine(CreateEnemies());
    }

    // Coroutine that creates the enemies
    IEnumerator CreateEnemies()
    {
        // Define a variable to hold the y position of the enemies (we don't want to change this)
        var ypos = 108.9f;
        // Define the number of enemies we want to create
        int numofenenemies = 10;

        // Loop until we have created the desired number of enemies
        while (eneCreated < numofenenemies)
        {
            // Generate a random x and z position for the enemy
            var xpos = Random.Range(77, 150);
            var zpos = Random.Range(-200,-240);

            // Instantiate the enemy object at the randomly generated position
            Instantiate(theEnemy, new Vector3(xpos, ypos, zpos), Quaternion.identity);

            // Wait for a short period of time before creating the next enemy
            yield return new WaitForSeconds(0.1f);

            // Increment the counter variable
            eneCreated += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Empty update method
    }
}
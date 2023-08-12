using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnDistance = 7f;
    public Vector3 rotationAngles = Vector3.zero; // Add this to set rotation angles

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnCube();
        }
    }

    void SpawnCube()
    {
        // Calculate the position in front of the player
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // Instantiate the cube at the calculated position with the specified rotation
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.Euler(rotationAngles));

        // Optionally, if you want to set the rotation of the cube after instantiation, you can do it like this:
        // cube.transform.rotation = Quaternion.Euler(rotationAngles);
    }
}

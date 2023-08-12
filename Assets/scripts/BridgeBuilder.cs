//using UnityEngine;

//public class BridgeBuilder : MonoBehaviour
//{
//    public GameObject bridgePrefab; // Assign your bridge plane prefab in the Inspector
//    private GameObject lastBridge;

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.M))
//        {
//            AttachBridge();
//        }
//    }

//    private void AttachBridge()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(transform.position, transform.forward, out hit))
//        {
//            if (hit.collider.gameObject.tag == "BridgePlane")
//            {
//                Vector3 bridgePosition = hit.collider.transform.position + transform.forward * 5f; // Adjust the distance here
//                Quaternion bridgeRotation = hit.collider.transform.rotation;
//                CreateBridge(bridgePosition, bridgeRotation);
//            }
//        }
//    }

//    private void CreateBridge(Vector3 position, Quaternion rotation)
//    {
//        GameObject newBridge = Instantiate(bridgePrefab, position, rotation);
//        if (lastBridge != null)
//        {
//            // Connect the new bridge with the last one (if any)
//            // You may need to adjust the position offset to fit your bridge model
//            newBridge.transform.position = lastBridge.transform.position + lastBridge.transform.forward * 5f;
//            newBridge.transform.rotation = lastBridge.transform.rotation;
//        }

//        lastBridge = newBridge;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnDistance = 7f;
    public Vector3 rotationAngles = Vector3.zero;

    // List to keep track of the spawned cubes
    private List<GameObject> spawnedCubes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (spawnedCubes.Count == 0)
            {
                // Spawn the first cube if there are no cubes in the list yet
                SpawnCube();
            }
            else
            {
                // Spawn a new cube and attach it to the last spawned cube
                AttachCube();
            }
        }
    }

    void SpawnCube()
    {
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.Euler(rotationAngles));
        spawnedCubes.Add(cube);
    }

    void AttachCube()
    {
        // Get the last spawned cube from the list
        GameObject lastCube = spawnedCubes[spawnedCubes.Count - 1];

        // Calculate the position in front of the last cube
        Vector3 spawnPosition = lastCube.transform.position + lastCube.transform.forward * spawnDistance;

        // Instantiate the new cube at the calculated position with the specified rotation
        GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.Euler(rotationAngles));

        // Add the new cube to the list
        spawnedCubes.Add(newCube);

        // Connect the new cube to the last cube using a fixed joint or some other attachment mechanism
        // For example, you can use a FixedJoint component:
        FixedJoint joint = newCube.AddComponent<FixedJoint>();
        joint.connectedBody = lastCube.GetComponent<Rigidbody>();
    }
}



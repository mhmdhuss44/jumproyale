using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public Terrain terrain;
    public float shrinkSpeed = 0.1f; // adjust this to control the speed of the shrinkage
    public float minimumSize = 50.0f; // adjust this to set the minimum size you want the terrain to shrink to
    public float finalSize = 100.0f; // adjust this to set the final size you want the terrain to shrink to

    private Vector3 originalSize;

    private void Start()
    {
        originalSize = terrain.terrainData.size;
        StartCoroutine(ShrinkTerrain());
    }

    IEnumerator ShrinkTerrain()
    {
        while (terrain.terrainData.size.x > minimumSize && terrain.terrainData.size.z > minimumSize)
        {
            yield return new WaitForSeconds(0.1f); // adjust this to control how often the terrain will shrink
            float newSize = Mathf.Max(terrain.terrainData.size.x - shrinkSpeed, finalSize);
            terrain.terrainData.size = new Vector3(newSize, terrain.terrainData.size.y, newSize);
        }
    }

    public void ResetTerrainSize()
    {
        terrain.terrainData.size = originalSize;
    }
}
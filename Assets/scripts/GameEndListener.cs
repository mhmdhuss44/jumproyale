using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndListener : MonoBehaviour
{
    // Start is called before the first frame update
    public SafeZone terrainShrinker;

    private void OnApplicationQuit()
    {
        if (terrainShrinker != null)
        {
            terrainShrinker.ResetTerrainSize();
        }
    }
}
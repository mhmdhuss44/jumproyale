using UnityEngine;

public class DangerZoneCounter : MonoBehaviour
{
    private int dangerZoneCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("danger"))
        {
            dangerZoneCount++;
            Debug.Log("Entering. Danger zone count: " + dangerZoneCount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("danger"))
        {
            dangerZoneCount--;
            Debug.Log("Exiting. Danger zone count: " + dangerZoneCount);
        }
    }

    public int GetDangerZoneCount()
    {
        return dangerZoneCount;
    }

    private void Update()
    {
        Debug.Log("Current danger zone count: " + dangerZoneCount);
    }
}

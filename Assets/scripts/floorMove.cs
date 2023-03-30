using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMove : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    int currentWayPointIndix = 0;
    [SerializeField] float speed = 1f;
    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIndix].transform.position) < .1f)
        {
            currentWayPointIndix++;
            if(currentWayPointIndix >= wayPoints.Length ) {
                currentWayPointIndix = 0;

            }
        }
        // to make the floor move between two points 
        transform.position= Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIndix].transform.position, speed * Time.deltaTime);
    }
}

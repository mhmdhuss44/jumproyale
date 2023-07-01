using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMish : MonoBehaviour
{
    [SerializeField] private Transform movepose;
    private NavMeshAgent m_Agent;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        m_Agent.destination = movepose.position;
    }

}

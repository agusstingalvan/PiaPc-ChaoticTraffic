using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianAIController : MonoBehaviour
{
    [SerializeField] Waypoint[] _waypoints;
    Transform _target;
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        //Set destination
        _target = _waypoints[0].GetComponent<Transform>();
        _agent.SetDestination(_target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}

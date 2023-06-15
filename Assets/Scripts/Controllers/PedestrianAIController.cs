using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianAIController : MonoBehaviour
{
    [SerializeField] Waypoint[] _waypoints;
    
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {

            if (!_waypoints[i].visited && _agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
            {

                Transform _target = _waypoints[i].GetComponent<Transform>();
                _agent.SetDestination(_target.position);
                _waypoints[i].visited = true;
                if ((_waypoints.Length - 1) == i)
                {
                    for (int j = 0; j < _waypoints.Length; j++)
                    {
                        _waypoints[j].visited = false;
                    }
                    i = 0;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}

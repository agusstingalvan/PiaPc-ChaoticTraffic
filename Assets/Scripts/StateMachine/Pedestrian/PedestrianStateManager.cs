using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianStateManager : MonoBehaviour
{
    public PedestrianBaseState _currentState;
    public PedestrianStateGoing _stateGoing = new PedestrianStateGoing();
    public PedestrianStateWaiting _stateWaiting = new PedestrianStateWaiting();
    public PedestrianStatePatience _statePatience = new PedestrianStatePatience();

    [HideInInspector]
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        _currentState = _stateGoing;
        _currentState.EnterState(this);


    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentState.OnTriggerEnter(this, other);
    }
    private void OnTriggerStay(Collider other)
    {
        _currentState.OnTriggerStay(this, other);
    }
}


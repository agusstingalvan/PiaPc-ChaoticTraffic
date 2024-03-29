using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class VehicleStateManager : MonoBehaviour
{
    public VehicleBaseState _currentState;
    public VehicleStateGoing _stateGoing = new VehicleStateGoing();
    public VehicleStateReviewing _stateReviewing = new VehicleStateReviewing();
    public VehicleStateWaiting _stateWaiting = new VehicleStateWaiting();
    //public VehicleStatePatience _statePatience = new VehicleStatePatience();

    public VehicleAIController _controller;

    [SerializeField]
    public LayerMask layerMaskCollider;

    [HideInInspector]
    public NavMeshAgent agent;

    public bool canStop;

    [SerializeField]
    public float stopDistance = 5f;
    public Transform haveVehicleInFront;
    public float timeForPatience = 10f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _controller = GetComponent<VehicleAIController>();
        canStop = true;
        stopDistance = 5f;

        _currentState = _stateGoing;
        _currentState.EnterState(this);
    }

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

    private void OnTriggerExit(Collider other)
    {
        _currentState.OnTriggerExit(this, other);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class VehicleStateManager : MonoBehaviour
{
    VehicleBaseState _currentState;
    VehicleStateGoing _stateGoing = new VehicleStateGoing();
    VehicleStateReviewing _stateReviewing = new VehicleStateReviewing();
    VehicleStateWaiting _stateWaiting = new VehicleStateWaiting();

    [HideInInspector]
    public NavMeshAgent agent;

    bool canStop;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canStop = true;

        _currentState = _stateGoing;
        _currentState.EnterState(this);
    }

    void Update()
    {
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight") && canStop)
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            if (trafficLightState.type == "red")
            {
                _currentState = _stateWaiting;
                _currentState.EnterState(this);

                canStop = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight"))
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            if (trafficLightState.type == "green")
            {
                _currentState = _stateGoing;
                _currentState.EnterState(this);
            }else if(trafficLightState.type == "yellow")
            {
                _currentState = _stateReviewing;
                _currentState.EnterState(this);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight"))
        {
            if (_currentState.type == "reviewing")
            {
                _currentState = _stateGoing;
                _currentState.EnterState(this);
            }

        }
    }
}

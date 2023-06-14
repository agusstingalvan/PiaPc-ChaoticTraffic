using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianStateGoing : PedestrianBaseState
{
    public override void EnterState(PedestrianStateManager pedestrianStateManager)
    {
        type = "going";
        pedestrianStateManager.agent.isStopped = false;
        pedestrianStateManager.agent.speed = 3;
    }
    public override void UpdateState(PedestrianStateManager pedestrianStateManager)
    {

    }

    public override void OnTriggerEnter(PedestrianStateManager pedestrianStateManager, Collider other)
    {
        
        if(other.transform.parent != null && other.transform.parent.CompareTag("TrafficLightPedestrian"))
        {
            TrafficPedestrianBase trafficPedestrianState = other.GetComponent<TrafficPedestrianManager>()._currentState;
            if(trafficPedestrianState.type == "red")
            {
                pedestrianStateManager._currentState = pedestrianStateManager._stateWaiting;
                pedestrianStateManager._currentState.EnterState(pedestrianStateManager);
            }
        }
    }

    public override void OnTriggerStay(PedestrianStateManager pedestrianStateManager, Collider other)
    {

    }

    public override void OnTriggerExit(PedestrianStateManager pedestrianStateManager, Collider other)
    {

    }
}
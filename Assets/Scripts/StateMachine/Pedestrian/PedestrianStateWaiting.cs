using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianStateWaiting : PedestrianBaseState
{
    public override void EnterState(PedestrianStateManager pedestrianStateManager)
    {
        type = "waiting";
        pedestrianStateManager.agent.isStopped = true;
        pedestrianStateManager.agent.speed = 0f;
    }
    public override void UpdateState(PedestrianStateManager pedestrianStateManager)
    {

    }

    public override void OnTriggerEnter(PedestrianStateManager pedestrianStateManager, Collider other)
    {

    }

    public override void OnTriggerStay(PedestrianStateManager pedestrianStateManager, Collider other)
    {
        //Reanuda su camino si detecta q es verde el semaforo
        if (other.transform.parent != null && other.transform.parent.CompareTag("TrafficLightPedestrian"))
        {
            TrafficPedestrianBase trafficPedestrianState = other.GetComponent<TrafficPedestrianManager>()._currentState;
            if(trafficPedestrianState.type == "green")
            {
                pedestrianStateManager._currentState = pedestrianStateManager._stateGoing;
                pedestrianStateManager._currentState.EnterState(pedestrianStateManager);
            }
        }
    }

    public override void OnTriggerExit(PedestrianStateManager pedestrianStateManager, Collider other)
    {

    }
}
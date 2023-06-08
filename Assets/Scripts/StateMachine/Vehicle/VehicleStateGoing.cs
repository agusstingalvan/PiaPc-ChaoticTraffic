using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStateGoing : VehicleBaseState
{
    public override void EnterState(VehicleStateManager vehicleStateManager) {
        type = "going";
        vehicleStateManager.agent.isStopped = false;
        vehicleStateManager.agent.speed = 3.5f;
    }
    public override void UpdateState(VehicleStateManager vehicleStateManager){
    
    }

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other)
    {
        //Frena si detecta q es rojo
        if (other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight") && vehicleStateManager.canStop)
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            if (trafficLightState.type == "red")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateWaiting;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);

                vehicleStateManager.canStop = false;
            }
        }
    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other){
    
    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other){
    
    }
}

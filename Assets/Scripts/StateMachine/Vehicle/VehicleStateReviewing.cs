using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStateReviewing : VehicleBaseState
{
    public override void EnterState(VehicleStateManager vehicleStateManager)
    {
        type = "reviewing";
        vehicleStateManager.agent.isStopped = false;
        vehicleStateManager.agent.speed = 1.5f;
    }
    public override void UpdateState(VehicleStateManager vehicleStateManager)
    {

    }

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other)
    {

    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other)
    {

    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other)
    {
        //Si esta en reviewing y sale del trigger pasa a going
        if (other != null && other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight"))
        {
            if (vehicleStateManager._currentState.type == "reviewing")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateGoing;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }
        }
    }
}

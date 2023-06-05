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

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager)
    {

    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager)
    {

    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager)
    {

    }
}

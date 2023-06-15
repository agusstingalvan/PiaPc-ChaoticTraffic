using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleStatePatience : VehicleBaseState
{
    public float time;
    public override void EnterState(VehicleStateManager vehicleStateManager)
    {
        type = "patience";
        vehicleStateManager.agent.isStopped = false;
        vehicleStateManager.agent.speed = 1.5f;
        time = 0;
    }
    public override void UpdateState(VehicleStateManager vehicleStateManager)
    {
        time += Time.deltaTime;
        if(time >= vehicleStateManager.timeForPatience)
        {
            vehicleStateManager._currentState = vehicleStateManager._stateGoing;
            vehicleStateManager._currentState.EnterState(vehicleStateManager);
        }
    }

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other)
    {

    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other)
    {

    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other)
    {
    }
}

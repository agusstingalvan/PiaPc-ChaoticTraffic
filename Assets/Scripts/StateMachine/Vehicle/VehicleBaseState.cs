using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleBaseState
{
    public string type = "";
    public abstract void EnterState(VehicleStateManager vehicleStateManager);
    public abstract void UpdateState(VehicleStateManager vehicleStateManager);

    public abstract void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other);

    public abstract void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other);

    public abstract void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other);
}

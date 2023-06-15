using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStateWaiting : VehicleBaseState
{
    public float time;
    public override void EnterState(VehicleStateManager vehicleStateManager)
    {
        type = "waiting";
        vehicleStateManager.agent.isStopped = true;
        vehicleStateManager.agent.speed = 0f;
        time = 0;
    }
    public override void UpdateState(VehicleStateManager vehicleStateManager)
    {
        //Si detecta un vehiculo alfrente:
        if (vehicleStateManager.haveVehicleInFront != null)
        {
            float distanceToVehicle = Vector3.Distance(vehicleStateManager.transform.position, vehicleStateManager.haveVehicleInFront.position);

            if (distanceToVehicle > vehicleStateManager.stopDistance)
            {
                // Reanudar la velocidad
                vehicleStateManager.haveVehicleInFront = null;

                vehicleStateManager._currentState = vehicleStateManager._stateGoing;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }
            else
            {
                // Detener cambiando a waiting
                vehicleStateManager._currentState = vehicleStateManager._stateWaiting;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }
        }

        time += Time.deltaTime;
        if (time > 5f)
        {
            vehicleStateManager.transform.Find("conito").gameObject.SetActive(true);
            //vehicleStateManager._currentState = vehicleStateManager._statePatience;
            //vehicleStateManager._currentState.EnterState(vehicleStateManager);
        }
    }

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other)
    {

    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other)
    {
        //Reanuda la marcha si detecta q es verde o amarrillo.
        if (other != null && other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight"))
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            if (trafficLightState.type == "green")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateGoing;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }
            else if (trafficLightState.type == "yellow")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateReviewing;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }

        }
    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other)
    {

    }
}

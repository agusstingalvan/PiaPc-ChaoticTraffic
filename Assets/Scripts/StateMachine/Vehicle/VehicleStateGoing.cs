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

        //Detectar si hay vehiculo delante y guardar la referencias, para luego en el estado waiting, poder reanudar la marcha.
        RaycastHit hit;
        // Dibujar el raycast en la escena para depuración
        Debug.DrawRay(vehicleStateManager.transform.position, vehicleStateManager.transform.forward * 8f, Color.red);


        if (Physics.Raycast(vehicleStateManager.transform.position, vehicleStateManager.transform.forward, out hit, 8f, vehicleStateManager.layerMaskCollider))
        {
            if (hit.collider != null)
            {
                VehicleAIController controllerVehicleCollider = hit.collider.GetComponent<VehicleAIController>();
                if (hit.collider.CompareTag("Vehicle") && vehicleStateManager._controller.initialDirection == controllerVehicleCollider.initialDirection)
                {
                    // Detener el vehículo y guardar la referencia al vehículo del otro de adelante
                    vehicleStateManager.haveVehicleInFront = hit.collider.transform;

                    //vehicleStateManager._currentState = vehicleStateManager._stateWaiting;
                    //vehicleStateManager._currentState.EnterState(vehicleStateManager);

                    float distanceToVehicle = Vector3.Distance(vehicleStateManager.transform.position, vehicleStateManager.haveVehicleInFront.position);
                 
                    //Velocidad inicial es de 3.5f;
                    if(distanceToVehicle < 7)
                    {
                        vehicleStateManager.agent.speed = 3f;
                    }
                    if(distanceToVehicle < 6)
                    {
                        vehicleStateManager.agent.speed = 2f;
                    }
                    if (distanceToVehicle < 5)
                    {
                        vehicleStateManager.agent.speed = .8f;
                    }
                    if (distanceToVehicle < 4)
                    {
                        vehicleStateManager.agent.speed = 0.5f;
                    }
                    if (distanceToVehicle <= 3)
                    {
                        vehicleStateManager._currentState = vehicleStateManager._stateWaiting;
                        vehicleStateManager._currentState.EnterState(vehicleStateManager);
                    }
                }
            }
        }
    }

    public override void OnTriggerEnter(VehicleStateManager vehicleStateManager, Collider other)
    {
        
         
        if (other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight") && vehicleStateManager.canStop)
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            //Frena si detecta q es rojo
            if (trafficLightState.type == "red")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateWaiting;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);

                vehicleStateManager.canStop = false;
            }
        }
    }

    public override void OnTriggerStay(VehicleStateManager vehicleStateManager, Collider other){

        if (other.transform.parent != null && other.transform.parent.CompareTag("TrafficLight") && vehicleStateManager.canStop)
        {
            TrafficLightBase trafficLightState = other.GetComponent<TrafficLightStateManager>()._currentState;
            //Desacelera si es amarrillo.
            if (trafficLightState.type == "yellow")
            {
                vehicleStateManager._currentState = vehicleStateManager._stateReviewing;
                vehicleStateManager._currentState.EnterState(vehicleStateManager);
            }
        }
    }

    public override void OnTriggerExit(VehicleStateManager vehicleStateManager, Collider other){
    
    }
}

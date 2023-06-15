using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianStatePatience : PedestrianBaseState
{
    private float time = 0;
    public override void EnterState(PedestrianStateManager pedestrianStateManager)
    {
        type = "patience";
        time = 0;
    }
    public override void UpdateState(PedestrianStateManager pedestrianStateManager)
    {
        time += Time.deltaTime;

        if (time >= 3f)
        {
            pedestrianStateManager.transform.GetComponentInChildren<MeshRenderer>().material.color = new Color(207f / 255f, 22f / 255f, 70f / 255f, 1f);
        }
        if (time >= 5f)
        {
            pedestrianStateManager.transform.GetComponentInChildren<MeshRenderer>().material.color = new Color(207f / 255f, 22f / 255f, 50f / 255f, 1f);
        }
        if (time >= 8f)
        {
            pedestrianStateManager.transform.GetComponentInChildren<MeshRenderer>().material.color = new Color(207f / 255f, 22f / 255f, 10f / 255f, 1f);
        }
        if (time >= 10f)
        {

            pedestrianStateManager._currentState = pedestrianStateManager._stateGoing;
            pedestrianStateManager._currentState.EnterState(pedestrianStateManager);

        }
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
            if (trafficPedestrianState.type == "green")
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPedestrianRed : TrafficPedestrianBase
{
    public override void EnterState(TrafficPedestrianManager lightStateMachine)
    {
        Debug.Log("State Pedestrian Red");
        lightStateMachine.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public override void UpdateState(TrafficPedestrianManager lightStateMachine)
    {

    }
    public override void OnTriggerEnter(TrafficPedestrianManager lightStateMachine)
    {

    }
    public override void OnTriggerStay(TrafficPedestrianManager lightStateMachine)
    {

    }
    public override void OnTriggerExit(TrafficPedestrianManager lightStateMachine)
    {

    }
}
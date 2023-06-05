using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateRed : TrafficLightBase
{
    public override void EnterState(TrafficLightStateManager lightStateMachine)
    {
        type = "red";
        lightStateMachine.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public override void UpdateState(TrafficLightStateManager lightStateMachine)
    {

    }
    public override void OnTriggerEnter(TrafficLightStateManager lightStateMachine)
    {

    }
    public override void OnTriggerStay(TrafficLightStateManager lightStateMachine)
    {

    }
    public override void OnTriggerExit(TrafficLightStateManager lightStateMachine)
    {

    }
}

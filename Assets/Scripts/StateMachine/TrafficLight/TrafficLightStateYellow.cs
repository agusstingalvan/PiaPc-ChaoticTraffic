using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateYellow : TrafficLightBase
{
    private float time = 0;
    public override void EnterState(TrafficLightStateManager lightStateMachine)
    {
        type = "yellow";
        time = 0;
        lightStateMachine.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
    public override void UpdateState(TrafficLightStateManager lightStateMachine)
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            lightStateMachine._currentState = lightStateMachine.stateRed;
            lightStateMachine._currentState.EnterState(lightStateMachine);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateGreen : TrafficLightBase
{
    private float time = 0;
    public override void EnterState(TrafficLightStateManager lightStateMachine)
    {
        Debug.Log("State Green");
        time = 0;
        lightStateMachine.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public override void UpdateState(TrafficLightStateManager lightStateMachine)
    {
        time += Time.deltaTime;
        if (time >= 7f ) {
            lightStateMachine._currentState = lightStateMachine.stateYellow;
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

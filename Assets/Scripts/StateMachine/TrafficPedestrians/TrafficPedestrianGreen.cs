using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPedestrianGreen : TrafficPedestrianBase
{
    private float time = 0;
    public override void EnterState(TrafficPedestrianManager lightStateMachine)
    {
        type = "green";
        time = 0;
        lightStateMachine.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public override void UpdateState(TrafficPedestrianManager lightStateMachine)
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            lightStateMachine._currentState = lightStateMachine.stateRed;
            lightStateMachine._currentState.EnterState(lightStateMachine);
        }
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

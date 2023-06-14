using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrafficPedestrianBase 
{
    public string type = "";
    public abstract void EnterState(TrafficPedestrianManager lightStateMachine);

    public abstract void UpdateState(TrafficPedestrianManager lightStateMachine);

    public abstract void OnTriggerEnter(TrafficPedestrianManager lightStateMachine);

    public abstract void OnTriggerStay(TrafficPedestrianManager lightStateMachine);
    public abstract void OnTriggerExit(TrafficPedestrianManager lightStateMachine);
}
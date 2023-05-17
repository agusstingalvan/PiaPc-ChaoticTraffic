
using UnityEngine;

public abstract class TrafficLightBase
{
    public abstract void EnterState(TrafficLightStateManager lightStateMachine);

    public abstract void UpdateState(TrafficLightStateManager lightStateMachine);

    public abstract void OnTriggerEnter(TrafficLightStateManager lightStateMachine);

    public abstract void OnTriggerStay(TrafficLightStateManager lightStateMachine);
    public abstract void OnTriggerExit(TrafficLightStateManager lightStateMachine);
}

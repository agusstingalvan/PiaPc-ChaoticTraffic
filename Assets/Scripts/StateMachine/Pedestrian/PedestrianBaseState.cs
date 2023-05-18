using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PedestrianBaseState 
{
    public abstract void EnterState(PedestrianStateManager pedestrianStateManager);
    public abstract void UpdateState(PedestrianStateManager pedestrianStateManager);

    public abstract void OnTriggerEnter(PedestrianStateManager pedestrianStateManager);

    public abstract void OnTriggerStay(PedestrianStateManager pedestrianStateManager);

    public abstract void OnTriggerExit(PedestrianStateManager pedestrianStateManager);
}


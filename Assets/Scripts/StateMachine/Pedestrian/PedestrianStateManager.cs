using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianStateManager : MonoBehaviour
{
    PedestrianBaseState _currentState;
    PedestrianStateGoing _stateGoing = new PedestrianStateGoing();
   PedestrianStateWaiting _stateWaiting = new PedestrianStateWaiting();



    void Start()
    {
        _currentState = _stateGoing;
        _currentState.EnterState(this);
        Debug.Log("En la state manager de pedestrian");

    }

    // Update is called once per frame
    void Update()
    {
    }
}


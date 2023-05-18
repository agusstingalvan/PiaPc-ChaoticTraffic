using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleStateManager : MonoBehaviour
{
    VehicleBaseState _currentState;
    VehicleStateGoing _stateGoing = new VehicleStateGoing();
    VehicleStateReviewing _stateReviewing = new VehicleStateReviewing();
    VehicleStateWaiting _stateWaiting = new VehicleStateWaiting();   



    void Start()
    {
        _currentState = _stateGoing;
        _currentState.EnterState(this);
        Debug.Log("En la state manager de vehiculo");

    }

    // Update is called once per frame
    void Update()
    {
    }
}

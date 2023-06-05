using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    TrafficLightStateManager _stateManager;

    void Start()
    {
        _stateManager = GetComponent<TrafficLightStateManager>();
    }

    void Update()
    {
       
    }
    private void OnMouseDown()
    {

        if (gameObject.name == "stick" && _stateManager._currentState.type == "red")
        {
            //Change initial status (Green for default)
            _stateManager._currentState = _stateManager.stateGreen;
            _stateManager._currentState.EnterState(_stateManager);
        }

    }
}

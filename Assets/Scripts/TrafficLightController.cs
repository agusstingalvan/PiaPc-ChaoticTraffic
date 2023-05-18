using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    TrafficLightStateManager _stateManager;

    // Start is called before the first frame update
    void Start()
    {
        _stateManager = GetComponent<TrafficLightStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnMouseDown()
    {

        if (gameObject.name == "stick" && _stateManager._currentState == _stateManager.stateRed)
        {
            Debug.Log("Clickkcckck left");
            _stateManager._currentState = _stateManager.stateGreen;
            _stateManager._currentState.EnterState(_stateManager);
        }

    }
}

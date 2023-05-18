using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPedestrianController : MonoBehaviour
{
    TrafficPedestrianManager _stateManager;

    // Start is called before the first frame update
    void Start()
    {
        _stateManager = GetComponent<TrafficPedestrianManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnMouseDown()
    {
           
        if (gameObject.name == "stickPedestrian" && _stateManager._currentState == _stateManager.stateRed)
        {
         Debug.Log("Click PEDERATIAN left");
            _stateManager._currentState = _stateManager.stateGreen;
            _stateManager._currentState.EnterState(_stateManager);
        }
            
    }
}

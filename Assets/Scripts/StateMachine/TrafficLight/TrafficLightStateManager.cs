using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateManager : MonoBehaviour
{
    public TrafficLightBase _currentState;


    //Instances of states
    public TrafficLightStateRed stateRed = new TrafficLightStateRed();
    public TrafficLightStateGreen stateGreen = new TrafficLightStateGreen();
    public TrafficLightStateYellow stateYellow = new TrafficLightStateYellow();   

    // Start is called before the first frame update
    void Start()
    {
        _currentState = stateRed;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPedestrianManager : MonoBehaviour
{
    public TrafficPedestrianBase _currentState;


    //Instances of states
    public TrafficPedestrianRed stateRed = new TrafficPedestrianRed();
    public TrafficPedestrianGreen stateGreen = new TrafficPedestrianGreen();
  

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
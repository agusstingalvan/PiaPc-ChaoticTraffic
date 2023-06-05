using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAIController : MonoBehaviour
{
    PedestrianStateManager _stateManager;
    void Start()
    {
        _stateManager = new PedestrianStateManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public bool visited;
    [SerializeField]
    //The values can be : north, east, west, sourth. All in minuscule
    public string address; 
    void Start()
    {
        visited = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

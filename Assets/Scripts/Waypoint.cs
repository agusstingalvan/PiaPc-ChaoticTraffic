using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public bool visited;
    void Start()
    {
        visited = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

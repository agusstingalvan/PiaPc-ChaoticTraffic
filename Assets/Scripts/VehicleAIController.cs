using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleAIController : MonoBehaviour
{
    VehicleStateManager _stateManager;


    [SerializeField] Waypoint [] _waypoints;
    int nextWaypoint;
    NavMeshAgent _agent;
    void Start()
    {
        _stateManager = new VehicleStateManager();
        _agent = GetComponent<NavMeshAgent>();
        nextWaypoint = 0;

        GameObject.Find("Vehicle").transform.Find("arrowLeft").gameObject.SetActive(false);
        GameObject.Find("Vehicle").transform.Find("arrowRight").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _waypoints.Length; i++)
        {
            if (!_waypoints[i].visited && _agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
            {
                Transform _target = _waypoints[i].GetComponent<Transform>();
                _agent.SetDestination(_target.position);
                _waypoints[i].visited = true;
                nextWaypoint = i;
            }
        }

        DetectDirection();

    }

    void DetectDirection()
    {
        Vector3 forward = transform.forward;

        // Obtener la dirección hacia el siguiente waypoint
        Vector3 toWaypoint = _waypoints[nextWaypoint].GetComponent<Transform>().position - transform.position;

        // Calcular el producto cruzado entre forward y toWaypoint
        float crossProduct = Vector3.Cross(forward, toWaypoint).y;

        if (crossProduct > 0)
        {
            //Debug.Log("El auto está doblando a la derecha");
            GameObject.Find("Vehicle").transform.Find("arrowLeft").gameObject.SetActive(false);
            GameObject.Find("Vehicle").transform.Find("arrowRight").gameObject.SetActive(true);
        }
        else if (crossProduct < 0)
        {
            //Debug.Log("El auto está doblando a la izquierda");
            GameObject.Find("Vehicle").transform.Find("arrowLeft").gameObject.SetActive(true);
            GameObject.Find("Vehicle").transform.Find("arrowRight").gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("El auto va en línea recta (no está doblando)");
            GameObject.Find("Vehicle").transform.Find("arrowLeft").gameObject.SetActive(false);
            GameObject.Find("Vehicle").transform.Find("arrowRight").gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null) {
            if(other.name == "stick" || other.tag == "Waypoint")
            {
                //DetectDirection();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.name == "stick")
            {
                //GameObject.Find("Vehicle").transform.Find("arrowLeft").gameObject.SetActive(false);
                //GameObject.Find("Vehicle").transform.Find("arrowRight").gameObject.SetActive(false);
            }
        }
    }
}

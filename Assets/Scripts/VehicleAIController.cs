using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleAIController : MonoBehaviour
{
    //VehicleStateManager _stateManager;


    [SerializeField] Waypoint [] _waypoints;
    int nextWaypoint;
    Transform _target;
    NavMeshAgent _agent;
    [SerializeField]
    string initialDirection;
    string _currentDirection;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        nextWaypoint = 0;
        DetectAdrress(gameObject.name, false, false);
        SelectRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
    }


    void SelectRandomDestination()
    {
        int indexRandom = Random.Range(0, _waypoints.Length);
        _target = _waypoints[indexRandom].GetComponent<Transform>();
        _agent.SetDestination(_target.position);
        _waypoints[indexRandom].visited = true;

        

        //Log in console for alert the player, Which is your destination
        _currentDirection = _target.GetComponent<Waypoint>().address.ToString();
        Debug.Log(_currentDirection);

        // Verifica el ángulo para determinar la dirección de giro

        if (initialDirection == "sourth" && _currentDirection == "east" || initialDirection == "west" && _currentDirection == "sourth" || initialDirection == "north" && _currentDirection == "west" || initialDirection == "east" && _currentDirection == "north")
        {
            //gira a la derecha
            DetectAdrress(gameObject.name, false, true);
        }
        else if (initialDirection == "sourth" && _currentDirection == "west" || initialDirection == "west" && _currentDirection == "north" || initialDirection == "north" && _currentDirection == "east" || initialDirection == "east" && _currentDirection == "sourth")
        {
            //gira a la izquierda
            DetectAdrress(gameObject.name, true, false);
        }
        else
        {
            //gira a la izquierda
            DetectAdrress(gameObject.name, false, false);
        }

    }
    void DetectAdrress(string name, bool left, bool right)
    {
        if(!left && !right)
        {
            GameObject.Find(name).transform.Find("arrowLeft").gameObject.SetActive(false);
            GameObject.Find(name).transform.Find("arrowRight").gameObject.SetActive(false);
        }
        else
        {
            GameObject.Find(name).transform.Find("arrowLeft").gameObject.SetActive(left);
            GameObject.Find(name).transform.Find("arrowRight").gameObject.SetActive(right);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && (other.name == "stick" || other.CompareTag("Waypoint"))) {
            //if(other.name == "stick" || other.tag == "Waypoint")
            //{
            //    //DetectDirection();
            //}
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Vehicle"))
        {
            Debug.Log("Collision entre vehiculos, jugador pierde");
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.name == "stick")
        {
            DetectAdrress(gameObject.name, false, false);
        }
    }
}

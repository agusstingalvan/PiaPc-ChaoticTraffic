using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class VehicleAIController : MonoBehaviour
{
    //VehicleStateManager _stateManager;


    [SerializeField] Waypoint [] _waypoints;
    int nextWaypoint;
    Transform _target;
    NavMeshAgent _agent;

    [SerializeField]
    public string initialDirection;

    string _currentDirection;

    GameManager _gameManager;

    [SerializeField]
    public bool hasCollided = false;

    void Start()
    {
        nextWaypoint = 0;

        _agent = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        

        DetectAdrress(gameObject.name, false, false);
        SelectRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && (other.name == "stick" || other.CompareTag("Waypoint"))) {

        }
        //Si el jugador llega al waypoint
        if (other != null && other.CompareTag("Waypoint") && other.GetComponent<Waypoint>().address == _currentDirection)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !hasCollided)
        {
            if (collision != null && collision.transform.CompareTag("Vehicle") && collision.transform.GetComponent<VehicleAIController>().initialDirection != initialDirection)
            {
                Debug.Log("Colision");
                hasCollided = true;

                _gameManager.totalCrashes--;
                _gameManager._uiManager.UpdateLives(_gameManager.totalCrashes);
                
                if (_gameManager.totalCrashes == 0)
                {
                    _gameManager.gameOver = true;
                    return;
                }
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.name == "stick")
        {
            DetectAdrress(gameObject.name, false, false);
        }
    }


    void DetectAdrress(string name, bool left, bool right)
    {
        if (!left && !right)
        {
            transform.Find("arrowLeft").gameObject.SetActive(false);
            transform.Find("arrowRight").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("arrowLeft").gameObject.SetActive(left);
            transform.Find("arrowRight").gameObject.SetActive(right);
        }
    }

    void SelectRandomDestination()
    {
        int indexRandom = Random.Range(0, _waypoints.Length);
        _target = _waypoints[indexRandom].GetComponent<Transform>();
        _agent.SetDestination(_target.position);
        _waypoints[indexRandom].visited = true;



        //Log in console for alert the player, Which is your destination
        _currentDirection = _target.GetComponent<Waypoint>().address.ToString();

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicle : MonoBehaviour
{
    [SerializeField]
    public int time;
    [SerializeField]
    public GameObject vehiclePrefab;

    [SerializeField]
    public float rotationY;

    [HideInInspector]
    public GameObject vehicleInstanceReference;

    [HideInInspector]
    public int countSpawnVehicles;
    // Start is called before the first frame update

    private void Start()
    {
    }

    private void Awake()
    {
        countSpawnVehicles = 0;
        StartCoroutine(Spawn(time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(int time)
    {
        yield return new WaitUntil(() => countSpawnVehicles < 3);

        Quaternion newRotation = Quaternion.Euler(0, rotationY, 0);
        vehiclePrefab.GetComponent<VehicleAIController>().mySpawn = this;
        vehicleInstanceReference = Instantiate(vehiclePrefab, transform.position, newRotation);
        countSpawnVehicles++;

        yield return new WaitForSeconds(time);

        StartCoroutine(Spawn(time));

    }
}

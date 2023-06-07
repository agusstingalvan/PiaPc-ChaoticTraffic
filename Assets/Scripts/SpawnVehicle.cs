using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class SpawnVehicle : MonoBehaviour
{
    [SerializeField]
    public int time;
    [SerializeField]
    public GameObject vehiclePrefab;

    [SerializeField]
    public float rotationY;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Spawn(time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn(int time)
    {
        yield return new WaitForSeconds(time);

        Quaternion newRotation = Quaternion.Euler(0, rotationY, 0);
        Instantiate(vehiclePrefab, transform.position, newRotation);

        StartCoroutine(Spawn(time));
    }
}

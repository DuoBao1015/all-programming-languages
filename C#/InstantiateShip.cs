using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateShip : MonoBehaviour
{
    public static InstantiateShip instance;

    public GameObject spaceShip1;

    float maxValue = 10;
    float minValue = -10;

    public float timeToDeath = 3f;
    void Start()
    {
        instance = this;
        SpawnSpaceShip(spaceShip1);
              
    }

    public void SpawnSpaceShip(GameObject shipPrefab)
    {
        //Instantiate(shipPrefab, new Vector3(Random.Range(minValue, maxValue), Random.Range(1, 6), Random.Range(minValue, maxValue)), Quaternion.Euler(90, 0, 0));      
        shipPrefab.transform.position = new Vector3(Random.Range(minValue, maxValue), Random.Range(1, 6), Random.Range(minValue, maxValue));
    }

}

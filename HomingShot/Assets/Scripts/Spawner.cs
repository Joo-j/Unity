using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    public GameObject missile;
    public Transform spawnLocation;


    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(missile, transform.position+spawnLocation.position, Quaternion.Euler(0, 0, 180));
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}

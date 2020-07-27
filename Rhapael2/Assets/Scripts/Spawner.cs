using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    public GameObject[] walls;


    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, walls.Length);
            if (rand >= 3)
            {
                rand = Random.Range(0, walls.Length);
            }

            int rand2 = Random.Range(-20, 20);
            if (rand2 <= -10 && rand2 >= 10)
            {
                rand2 = Random.Range(-20, 20);
            }

            Vector3 randomLocation = new Vector3(rand2, 0, 0);
            Instantiate(walls[rand], transform.position+ randomLocation, Quaternion.Euler(0,0,180));
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}

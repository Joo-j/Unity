using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject goSpawn;
    public float fDifficulty = 10f;

    float fSpawn = 0;

	
	// Update is called once per frame
	void Update () {
        fSpawn += fDifficulty * Time.deltaTime;
        fDifficulty += Time.deltaTime * 4f;

        while (fSpawn > 1)
        {
            fSpawn -= 1;
            Vector3 v3Pos = new Vector3(Random.value * 40f - 20f, 0, Random.value * 40f - 20f) + transform.position;
            GameObject goCreate = Instantiate(goSpawn, v3Pos, Quaternion.Euler(0, Random.value*360f, Random.value*30f));
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoving : MonoBehaviour {

    void Start()
    {
        InvokeRepeating("Rot", 3, 6);
    }

    void Rot()
    {
        int rand = Random.Range(0, 360);
        transform.Rotate(0, 0, rand);   
}
}

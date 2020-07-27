using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Grass : MonoBehaviour
    {
   // public GameManger gm;

    void Start()
    {
        //gm = gameObject.GetComponent<GameManger>();
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            //gm.AddScore();
            }
        }
    }

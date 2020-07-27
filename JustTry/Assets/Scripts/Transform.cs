using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour {

    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, 90);
        }
    } 
}

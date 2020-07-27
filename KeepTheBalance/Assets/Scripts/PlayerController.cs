using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float rSpeed = 200f;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
         if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rSpeed * Time.deltaTime, 0);
        }
         if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rSpeed * Time.deltaTime, 0);
        }

    }
}

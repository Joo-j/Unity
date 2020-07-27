using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public float jumpSpeed = 10f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
            transform.Translate(new Vector3(0, jumpSpeed, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -29f, 29f), Mathf.Clamp(transform.position.y, 0, 79f), Mathf.Clamp(transform.position.z, -10f, 10f));
    }
}

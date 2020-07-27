using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale += Time.fixedDeltaTime * 0.01f;
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * 7f);
        rb.velocity += transform.rotation * (Input.GetAxisRaw("Horizontal") * Vector3.right) * 10f * Time.deltaTime;
        rb.velocity += transform.rotation * (Input.GetAxisRaw("Vertical") * Vector3.up) * 10f * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

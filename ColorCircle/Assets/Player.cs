using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float moveForce = 100f;
    float movement = 0f;
    ColorSeter cs;

    void Start()
    {
        cs = GetComponent<ColorSeter>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * moveForce);
    }

    void OnTriggerEnter2D(Collider2D col)
    {       
        if (cs.time <= 0.01)
        {
            if (col.tag != cs.currentColor)
            {
                Debug.Log("GAME OVER!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}

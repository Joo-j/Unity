using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    Rigidbody rb;
    Animator am;
    private float h;
    private float v;
    private float moveX;
    private float moveZ;
    public float speedH = 50f;
    public float speedZ = 80f;
    public float speedJ = 10f;
    public float speedT = 10f;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        am = GetComponent<Animator>();
    }

    void Update()
    {
        Time.timeScale += Time.fixedDeltaTime * 0.01f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            am.Play("JUMP00", -1, 0);
            rb.velocity = new Vector3(0, speedJ, 0);
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        am.SetFloat("h", h);
        am.SetFloat("v", v);

        moveX = h * speedH * Time.deltaTime;
        moveZ = v * speedZ * Time.deltaTime;

        if (moveZ <= 0)
        {
            moveX = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (v >= 0)
            {
                this.transform.Rotate(0, -speedT * 10 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, speedT * 10 * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.R))
        {
            if (v >= 0)
            {
                this.transform.Rotate(0, speedT * 10 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, -speedT * 10 * Time.deltaTime, 0);
            }
        }
        rb.velocity = new Vector3(moveX, 0, 0); 
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Floor")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       }
    }



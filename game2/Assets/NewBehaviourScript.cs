using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Animator animator;
    public Rigidbody r;
   
    private float h;
    private float v;
    private float moveX;
    private float moveZ;
    private float speedH = 500f;
    private float speedZ = 800f;


    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        animator.SetFloat("h", h);
        animator.SetFloat("v", v);
        moveX = h * speedH * Time.deltaTime;
        moveZ = v * speedZ * Time.deltaTime;
        if (moveZ <= 0)
        {
            moveX = 0;
        }
        r.velocity = new Vector3(moveX, 0, moveZ);

    
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Animator animator;
    public Rigidbody r;
    
    private float moveX;
    private float moveZ;
    private float speedH = 50f;
    private float speedZ = 80f;
    private int hp = 5;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        r = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
    
        moveX =  speedH * Time.deltaTime;
        moveZ =  speedZ * Time.deltaTime;
     
        r.velocity = new Vector3(moveX, 0, moveZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cube")
        {
            animator.Play("attack", -1, 0);
        }



        if (collision.collider.tag == "Bullet")
        {
            hp--;
            if (hp == 0)
            {
                animator.Play("fallingback", -1, 0);
                this.transform.Translate(Vector3.back * speedZ * Time.deltaTime);
            }
        }
    }
}

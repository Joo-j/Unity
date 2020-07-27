using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

    public Animator animator;
    public Rigidbody r;
    private int hp = 10;
    private float speedZ = 80f;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        r = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        r.velocity = new Vector3(speedZ, 0, speedZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "zombie")
        {
            hp--;
            if (hp == 0)
            {
                animator.Play("Exit", -1, 0);
            }
        }
    }

}

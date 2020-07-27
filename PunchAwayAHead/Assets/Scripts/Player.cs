using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public Animator animator;
    //public Animation[] attack; 

    void Start()
    {
        animator.Play("Run");

    }

    void Update()
    {
        //transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       // int rand = Random.Range(0, attack.Length);
       // string a = attack[rand].ToString();
        if (other.tag != gameObject.tag)
        {
               animator.Play("Jab");
        }
    }


}
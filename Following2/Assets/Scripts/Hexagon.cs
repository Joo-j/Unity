﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public Rigidbody2D rb;

    public float shrinkSpeed = 3f;


	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.localScale = Vector3.one * 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if(transform.localScale.x <= .1f)
        {
            Destroy(gameObject);
        }
	}
}
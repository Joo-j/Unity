using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    // movement
    public float speed = 15.0f;
    public Transform EffectLocation;
   // public GameObject Effect;
    private Vector3 moveDirection;
    private Rigidbody playerRigidBody;
    private Transform playerMesh;
    public Joystick joystick;

    // Use this for initialization
    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        playerMesh = transform.GetChild(0).transform;
    }
        void Update() {
        //  moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
         moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        /*
        if (joystick.Horizontal >= .2f || joystick.Vertical >= .2f) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
        else if(joystick.Horizontal <= -.2f || joystick.Vertical <= -.2f)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        */

        /* if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Instantiate(Effect, EffectLocation.position, EffectLocation.rotation);
        }*/
    }

        void FixedUpdate()
        {
            // update movement
            playerRigidBody.MovePosition(playerRigidBody.position + transform.TransformDirection(moveDirection * speed * Time.fixedDeltaTime));
            // rotate player to face the right direction
            RotatePlayer();
    }

        // Rotate player to face direction of movement
        void RotatePlayer()
        {
            Vector3 dir = moveDirection;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            if (Vector3.Magnitude(dir) > 0.0f)
            {
                playerMesh.localRotation = targetRotation;
            }
        }
    
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    private bool playerIsOVerLapping = false;
    public Transform player;
    public Transform reciever;
	
	// Update is called once per frame
	void Update () {
        if (playerIsOVerLapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true: The player has moved across the portal

        if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * -portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOVerLapping = false;
            }
        }
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Block")
        {
            playerIsOVerLapping = true;
        }
    }

    void OnTriggerEnterExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Block")
        {
            playerIsOVerLapping = false;
        }
    }
}

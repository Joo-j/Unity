using UnityEngine;
using System.Collections;

public class BoxPull : MonoBehaviour
{

    public bool beingPushed;
    float xPos;

    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPushed == true)
        {
            xPos = transform.position.x;
        }

    }
}


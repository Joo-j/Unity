using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodWall : MonoBehaviour{

    public float speed = 10;
    public int score = 0;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != gameObject.tag)
        {
            Destroy(gameObject);
            UserInterface ui = other.gameObject.GetComponent<UserInterface>();
            ui.UpdateHP(10);
            Debug.Log("Good job");
        }

    }
}

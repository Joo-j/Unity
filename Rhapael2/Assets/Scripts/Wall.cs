using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour {

    public float speed = 10;
    public int score = 0;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
        score += 1;
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != gameObject.tag)
        {
            UserInterface ui = other.gameObject.GetComponent<UserInterface>();
            ui.UpdateHP(-15);
            Destroy(gameObject);

            if (ui.curHP<=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Game Over");
            }
        }

    }
}

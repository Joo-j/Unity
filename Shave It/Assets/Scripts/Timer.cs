using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float time;

    void Start()
    {
        time = 60;
    }

    void Update()
    {
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                GameOver();
            }
        }

        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();

        if (time <= 10)
        {
            uiText.text = " Time : " + "<color=#ff0000>" + t.ToString() + "</color>";
        }
        else
        {
            uiText.text = " Time : " + t.ToString();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Over");
    }
}
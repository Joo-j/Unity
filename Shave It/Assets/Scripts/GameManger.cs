using UnityEngine;
using System.Collections;
using UnityEngine.UI;


    public class GameManger : MonoBehaviour
{
      int score = 0;

    public void AddScore()
    {
        score++;
        Text uiText = GetComponent<Text>();
        uiText.text = " Score : " + score.ToString();
    }
}


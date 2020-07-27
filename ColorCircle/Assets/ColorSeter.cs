using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorSeter : MonoBehaviour {

    public string currentColor;
    public float time = 4f;
    public float timeSpeed = 1.0f;
    string textColor;

    void Start()
    {
        SetRandomColor();        
    }

    void Update()
    {
        Text uiText = GetComponent<Text>();

        time -= Time.deltaTime * timeSpeed;
        int t = Mathf.FloorToInt(time);
        uiText.text = textColor + currentColor + "(" + t.ToString() + ")" + "</color>";
     
            timeCounter();
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                textColor = "<color=#000fff>";
                break;
            case 1:
                currentColor = "Yellow";
                textColor = "<color=#00ff00>";
                break;
            case 2:
                currentColor = "Pink";
                textColor = "<color=#f00000>";
                break;
            case 3:
                currentColor = "Magenta";
                textColor = "<color=#0000ff>";
                break;
        }
    }

        public void timeCounter()
        {
            if (time <= 0)
            {
                time = 4;
                timeSpeed += 0.1f;
                SetRandomColor();
            }
        }
    }
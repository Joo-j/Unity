using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    public float maxHP = 100;
    public float curHP;
    public Slider HP;
    public Text text;
    public float time = 90f;

    // Use this for initialization
    void Start()
    {
        SetHP(maxHP);
    }

     void Update()
    {
        if(time < 600f)
        {
            time += Time.deltaTime;
            if (time >= 600f) time = 600f;
        }
        int t = Mathf.FloorToInt(time);
        
        text.text = "현재시간: " + t.ToString()+ "시";   
    }
    
    public void SetHP(float value)
        {
            curHP = value;
            HP.value = curHP;
        }
	
	// Update is called once per frame
	public void UpdateHP (float value) {
        if (curHP >= 100) curHP = 100;
        curHP += value;
        HP.value = curHP;
	}
}

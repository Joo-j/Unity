using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tet : MonoBehaviour {

    float fall = 0;
    public float fallSpeed = 1f;
    public bool allowRotation = true;
    public bool limitRotation = false;
    [SerializeField] private Transform leftCheck;                        
    [SerializeField] private Transform rightCheck;                     
    const float radius = .1f;
  
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckUserInput();
	}

    void CheckUserInput()
    {
        /* if (Input.GetKeyDown(KeyCode.RightArrow))
         {
             transform.position += new Vector3(1, 0, 0);
             if (CheckIsValidPosition())
             {
                 FindObjectOfType<Game>().UpdateGrid(this);
             }
             else
             {
                 transform.position += new Vector3(-1, 0, 0);
             }        
         }
         else if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             transform.position += new Vector3(-1, 0, 0);
             if (CheckIsValidPosition())
             {
                 FindObjectOfType<Game>().UpdateGrid(this);
             }
             else
             {
                 transform.position += new Vector3(1, 0, 0);
             }
         }
         else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.Space))*/
        if(Input.GetKeyDown(KeyCode.Space)){
            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
            }

            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                if (limitRotation)
                {

                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                }
            }
        }
        //else if (Input.GetKeyDown(KeyCode.DownArrow)|| Time.time - fall >= fallSpeed)
        else if (Time.time - fall >= fallSpeed)

        {
            transform.position += new Vector3(0, -1, 0);
            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<Game>().DeleteRow();
                if (FindObjectOfType<Game>().CheckIsAboveGrid(this))
                {
                        FindObjectOfType<Game>().GameOver();
                 } 
                enabled = false;
                FindObjectOfType<Game>().SpawnNextTet();
            }
            fall = Time.time;
        }
        /*
        if (Physics2D.OverlapCircle(rightCheck.position, radius))
        {
            transform.position += new Vector3(-1, 0, 0); ;
        }
        else if(Physics2D.OverlapCircle(leftCheck.position, radius))
        {
            transform.position += new Vector3(1, 0, 0); ;
        }*/
    }

    bool CheckIsValidPosition()
    {
        foreach(Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<Game>().Round(mino.position);
            if (FindObjectOfType<Game>().CheckIsInsideGrid(pos) == false)
            {
                return false;
            }
            if(FindObjectOfType<Game>().GetTransformGridPosition(pos) != null && FindObjectOfType<Game>().GetTransformGridPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}

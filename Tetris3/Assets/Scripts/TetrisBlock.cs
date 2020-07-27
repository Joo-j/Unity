using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour {
    //private float previousTime = 0;
    //public float fallTime = 0.8f;
    //public static int height = 20;
    //public static int width = 10;
    bool nextBlock = false;
    bool gameOver = false;


    //public Vector3 rotationPoint;
    //private static Transform[,] grid = new Transform[width, height];
    //Rigidbody2D rb;

    // Use this for initialization
    void Start () {
       // rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        /* if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             transform.position += new Vector3(-1, 0, 0);
             if (!ValidMove()) transform.position -= new Vector3(-1, 0, 0);
         }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
         {
             transform.position += new Vector3(1, 0, 0);
             if (!ValidMove()) transform.position -= new Vector3(1, 0, 0);
         }
         else if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
             if (!ValidMove()) transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
         }

        //시간차를 두고 무언가를 반복하기 위함, previousTime에 사건이 일어날때의 시간을 넣어두고 다음 사건이 일어날때 시간이 또 경과되니까 그전에 넣어둔 previousTime보다는 시간이 앞서 있을것이기 때문에 반복의 효과를 줌 
         if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)) {
             transform.position += new Vector3(0, -1, 0);
             if (!ValidMove())
             {
                 transform.position -= new Vector3(0, -1, 0);
                 this.enabled = false;
                 FindObjectOfType<SpawnTetromino>().NewTetromino();
             }

                 previousTime = Time.time;

         }
         if (!ValidMove()) //계속 검사, 땅에 닿았을때(움직일 수 없다고 판단될때) 새로운 벽돌이 나오기 위함, 벽돌이 맵 바깥으로 나갔을때 잡아주기 위함
        {
         CheckForLines();

        }*/

        //땅에 터치되었을때, 다른 블록들 위에 터치되었을때로 변경해주면됨
        //땅에 터치 된 순간 딱딱한 느낌의 블럭으로
        //10개의 박스 콜라이더를 (모든 줄마다) 0.1크기의 줄로 쫙 깔아서 한줄이 다 차있는 상태면 delete, delete기능이 중요
        //delete후 블럭들이 떨어지면서 충돌을 일으킬수 있기때문에 멈춰있을때만 staying
        if (gameOver)
        {
            Debug.Log("GameOver");
            FindObjectOfType<SpawnTetromino>().GameOver();
        }
        if (nextBlock) {
            this.enabled = false;
            FindObjectOfType<SpawnTetromino>().NewTetromino();            
        }
     }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Over")
        {
            gameOver = true;
        }

        if (collision.collider.tag == "Ground")
    {
            nextBlock=true;         
        }
    }

    /*
    void CheckForLines()
    {
        for(int i = height-1; i>=0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
            }
        }
    }


    void AddToGrid()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool HasLine(int i)
    {
        for(int j=0; j<width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for(int j=0; j<width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j,i] = null;
        }
    }  


    bool ValidMove()
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

            //벽돌이 그리드 밖으로 튕겨나갔을때, 게임오버 등
            //-0.0001 은 0으로 판단됨
                if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
                {
                    return false;
                }

            //땅에 닿았을때, 땅에 닿으면 roundedX와 roundedY자리는 블록이 들어서고 null값에서 벗어나게되기 때문에 이것을 사용
            //여기서 안되는 이유는 블록이 roundedX,Y grid의 자리로 인식되지 않기 때문
            //계속 떨어지는 상태이기 때문에 인식을 못함?
            //지금 까지 됬던 이유는 그리드를 잘못 설정했기 때문에 벽이 튕겨나간것으로 판단되서
            
            if (grid[roundedX, roundedY] != null) return false;

        }
            return true;
        }    */
}

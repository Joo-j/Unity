using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop: MonoBehaviour {
    public static int gridWidth = 30;
    public static int gridHeight = 80;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];
    //float time = 1;       
    void Start()
    {
        InvokeRepeating("SpawnNextBlock", 2, 3);
    }

     void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -29f, 29f), Mathf.Clamp(transform.position.y, 0, 79f), Mathf.Clamp(transform.position.z, -10f, 10f));
    }

    public bool IsFullRowAt(int y)
    {
        for(int x = -29; x<gridWidth; ++x)
        {
            if(grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void Delete(int y)
    {
        for(int x=-29; x<gridWidth; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MoveRowDown(int y)
    {
        for(int x=-29; x<gridWidth; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].transform.position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowsDown(int y)
    {
        for(int i=y; i<gridHeight; ++i)
        {
            MoveRowDown(i);
        }
    }

    public void DeleteRow()
    {
        for (int y = 1; y < gridHeight; ++y)
        {
            if (IsFullRowAt(y))
            {
                Delete(y);
                MoveAllRowsDown(y + 1);
                --y;
            }
        }
    }

    public void SpawnNextBlock()
    {
        float x = Random.Range(-26f, 26f);
        GameObject nextBlcok = (GameObject)Instantiate(Resources.Load(GetRandomBlock()), new Vector3(x, 75.0f, -3), Quaternion.identity);
    }

    string GetRandomBlock()
    {
        int randomBlock = Random.Range(1, 7);
        string randomBlockName = "";

        switch (randomBlock)
        {
            case 1:
                randomBlockName = "Prefabs/Blocks/Kieok";
                break;
            case 2:
                randomBlockName = "Prefabs/Blocks/KieokNieun";
                break;
            case 3:
                randomBlockName = "Prefabs/Blocks/Nieun";
                break;
            case 4:
                randomBlockName = "Prefabs/Blocks/Oh";
                break;
            case 5:
                randomBlockName = "Prefabs/Blocks/Square";
                break;
            case 6:
                randomBlockName = "Prefabs/Blocks/Straight";
                break;
        }
        return randomBlockName;
    }
}

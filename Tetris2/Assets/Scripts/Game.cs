﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 10;
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];
	// Use this for initialization
	void Start () {
        SpawnNextTet();
	}

    public bool CheckIsAboveGrid(Tet tet)
    {     
        for(int x = 0; x < gridWidth; ++x)
        {
            foreach(Transform mino in tet.transform)
            {
                Vector2 pos = Round(mino.position);
                if (pos.y > gridHeight - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
	
	public bool IsFullRowAt(int y)
    {
        for(int x =0; x<gridWidth; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteMinoAt(int y)
    {
        for (int x = 0; x < gridWidth; ++x){
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MoveRowDown(int y)
    {
        for(int x = 0; x < gridWidth; ++x)
        {
            if(grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowDown(int y)
    {
        for(int i=y; i<gridHeight; ++i)
        {
            MoveRowDown(i);
        }
    }

    public void DeleteRow()
    {
        for(int y=0; y<gridHeight; ++y)
        {
            if (IsFullRowAt(y)){
                DeleteMinoAt(y);
                MoveAllRowDown(y + 1);
                --y;
            }
        }
    }

    public void UpdateGrid(Tet tet)
    {
        for (int y = 0; y < gridHeight; ++y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    if(grid[x, y].parent == tet.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        foreach(Transform mino in tet.transform)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }


    public Transform GetTransformGridPosition(Vector2 pos)
    {
        if (pos.y > gridHeight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public void SpawnNextTet()
    {
        GameObject nextTet = (GameObject)Instantiate(Resources.Load(GetRandomTet(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round (Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    string GetRandomTet()
    {
        int randomTet = Random.Range(1, 8);

        string randomTetName = "Prefabs/T_t";

        switch (randomTet)
        {
            case 1:
                randomTetName = "Prefabs/T_t";
                break;
            case 2:
                randomTetName = "Prefabs/T_long";
                break;
            case 3:
                randomTetName = "Prefabs/T_square";
                break;
            case 4:
                randomTetName = "Prefabs/T_j";
                break;
            case 5:
                randomTetName = "Prefabs/T_l";
                break;
            case 6:
                randomTetName = "Prefabs/T_s";
                break;
            case 7:
                randomTetName = "Prefabs/T_z";
                break;
        }

        return randomTetName;
    }

    public void GameOver()
    {
        Debug.Log("GameOver!");
        SceneManager.LoadScene("GameOver");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : MonoBehaviour {
    public int[] touching = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private static Transform[,] grid = new Transform[10, 20];

    void Start() {
    }

    // Update is called once per frame
    void Update() {
       for(int i=0; i<10; i++)
        {
            if (touching[i] == 10) DeleteLine(i);
        }
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < 10; j++)
        {
            Destroy(grid[j, i].gameObject);
        }
    }

}

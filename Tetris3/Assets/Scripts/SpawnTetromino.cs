using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnTetromino : MonoBehaviour {

    public GameObject[] Tetrominoes;

	// Use this for initialization
	void Start () {
        NewTetromino();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewTetromino()
    {
        Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], new Vector2(Random.Range(2f, 8f), 19f), Quaternion.identity);
    }


    public void GameOver()
    {
        Debug.Log("GameOver!");
        SceneManager.LoadScene("GameOver");
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
}


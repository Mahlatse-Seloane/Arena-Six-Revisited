using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;
	public GameObject[] targets;
	private bool gameOver = false;

	void Start ()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public void WhoWon(int player)
	{
		targets [player-1].SetActive(false);
		gameOver = true;

        UIManager.instance.WhoWon(player);
        SceneManager.LoadScene((player == 1) ? "Player1Wins": "Player2Wins");
    }

	public bool IsGameOver()
	{
		return gameOver;
	}
}

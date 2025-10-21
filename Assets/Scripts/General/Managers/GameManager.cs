using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool StartFight { get; set; }
    public GameObject[] targets;
    public bool IsGameOver { get; set; }
    private bool optionsAfterWin = false;
    private float delay = 11f;

	void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	void Update()
	{
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            UIManager.instance.BeginningOfTheGame((int)delay);
            if (delay <= 2.9)
                StartFight = true;
        }

		optionsAfterWin = UIManager.instance.optionsAfterWin;
		if(optionsAfterWin)
		{
			if (Input.GetButton ("Menu")) 
				SceneManager.LoadScene ("Menu");
			else if(Input.GetButton ("Submit"))
				SceneManager.LoadScene ("sc_Level01");
		}
	}

    public void WhoWon(int player)
    {
        targets[player - 1].SetActive(false);
        IsGameOver = true;

        UIManager.instance.WhoWon(player);
        SceneManager.LoadScene((player == 1) ? "Player1Wins" : "Player2Wins");
    }

    //private IEnumerator DelayExecution(float amount, float duration = 0f)
    //{
    //    originalPos = mainCam.transform.localPosition;

    //    while (duration > 0)
    //    {
    //        StartCameraShake(amount);
    //        duration -= Time.deltaTime;
    //        yield return null;
    //    }

    //    StopCameraShake();
    //}
}

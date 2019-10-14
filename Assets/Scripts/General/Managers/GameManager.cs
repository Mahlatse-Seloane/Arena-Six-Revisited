using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool StartFight;

	public Text FightText;
 
	float delay = 5f;
	float delayLimit = -1f;

	// Use this for initialization
	void Start () {
		instance = this;
		/*******************
		 * 
		 * if ( instance == null )
		 * {
		 * 	instance = this;
		 * }
		 * else if ( instance != this )
		 * {
		 * 	Destroy(gameObject)
		 * }
		 * DontDestroyOnLoad(gameObject);
		 * *************/
	}

	void Update()
	{
		if (delay > delayLimit) 
		{


			delay -= Time.deltaTime;

			if (delay > 1) 
			{
				int a = (int)delay - 1;
				FightText.text = "" + a;
			}

			if (delay > 0 &&delay < 2f) 
			{
				FightText.text = "FIGHT";
			}

			if (delay > 0 &&delay < 1f) 
			{
				FightText.text = " ";
				StartFight = true;
			}
	}
}
}

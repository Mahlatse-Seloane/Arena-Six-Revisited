using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager1 : MonoBehaviour {

	public bool player1Ready;
	public bool player2Ready;

	public float delay;
	float delayLimit = 1f;
	public Text readyP1;
	public Text readyP2;

	// Update is called once per frame
	void Update () 
	{  
		if (SceneManager.GetActiveScene ().buildIndex == 1) 
		{
			if (player1Ready == true && player2Ready == true) 
			{
				delay += Time.deltaTime;
				if (delay > delayLimit)
				{
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
				}
			}
		}

		if (SceneManager.GetActiveScene ().buildIndex == 3) 
		{
			if (Input.GetButton ("Cancel")) 
			{
				SceneManager.LoadScene ("Menu");
			}
		}
	}
		

	void FixedUpdate()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 1)
		{
			if (Input.GetButton ("ReadyP1")) 
			{
				readyP1.text = "Ready";
				player1Ready = true;
			}

			if (Input.GetButton ("ReadyP2"))
			{
				readyP2.text = "Ready";
				player2Ready = true;
			}
		}
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene (name);
	}

	public void Quitgame()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}

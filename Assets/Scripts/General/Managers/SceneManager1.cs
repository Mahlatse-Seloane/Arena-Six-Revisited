using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager1 : MonoBehaviour {

	public bool player1Ready { get; set; }
	public bool player2Ready { get; set; }
	private float delay;
	private float delayLimit = 1f;
	public Text readyP1;
	public Text readyP2;
	public KeyCode ReadyPlayer1, ReadyPlayer2;

	void Update () 
	{
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKey (ReadyPlayer1))
            {
                audioManager.instance.Play ("CharacterSelect");
                readyP1.text = "Ready";
                player1Ready = true;
            }

            if (Input.GetKey (ReadyPlayer2))
            {
                audioManager.instance.Play("CharacterSelect");
                readyP2.text = "Ready";
                player2Ready = true;
            }
        }

		if (SceneManager.GetActiveScene().buildIndex == 1 && (player1Ready == true && player2Ready == true))
		{
			delay += Time.deltaTime;
			if (delay > delayLimit)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (SceneManager.GetActiveScene ().buildIndex == 3 || SceneManager.GetActiveScene ().buildIndex == 1) 
		{
			if (Input.GetButton ("Cancel")) 
				SceneManager.LoadScene ("Menu");
		}
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene (name);
        Time.timeScale = 1f;
    }

	public void Quitgame()
	{
		audioManager.instance.Play ("QuitButton");
		Application.Quit ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
	public static InputManager instance;
	public GameObject PauseMenu;
    public GameObject Controls;
    public bool paused = false;

	void Start()
	{
		instance = this;
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause") && paused == false) 
		{
			pause ();
		} 
		else
		{
			if (Input.GetButtonDown ("Pause") && paused == true) 
			{
				unpause ();
			}
            else
            {
                if (SceneManager.GetActiveScene().buildIndex == 2 && paused)
                {
                    if (Input.GetButton("Cancel"))
                    {
                        ControlsMenuBackward();
                    }
                }
            }
		}
	}

	public void pause()
	{
		Time.timeScale = 0f;
		paused = true;
        FindObjectOfType<audioManager>().StopPlaying("Charging");
        PauseMenu.SetActive(true);
    }

    public void ControlsMenuForward()
    {
        FindObjectOfType<audioManager>().StopPlaying("Charging");
        Controls.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void ControlsMenuBackward()
    {
        Controls.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void unpause()
	{
		Time.timeScale = 1f;
		paused = false;
        FindObjectOfType<audioManager>().StopPlaying("Charging");
        PauseMenu.SetActive(false);
        Controls.SetActive(false);
    }
}

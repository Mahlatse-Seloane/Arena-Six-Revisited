using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsGm : MonoBehaviour 
{
	void Update () 
	{
        if (Input.GetButton("Cancel"))
			SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gm : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("sc_Level01");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour 
{
    public GameObject flames;

	void Update () 
    {
		if(!PlayerManager.instance.IsGameOver())
        {
            //Instantiate(flames, transform.position, Quaternion.identity);
        }
	}
}

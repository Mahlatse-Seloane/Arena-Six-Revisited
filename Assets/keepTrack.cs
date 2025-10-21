using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepTrack : MonoBehaviour {

    public GameObject cameraRig;
	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        float posX = cameraRig.transform.position.x;

        transform.position = new Vector3(posX,transform.position.y, -450f);
	}
}

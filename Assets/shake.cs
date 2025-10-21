using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

    public CameraShake camShake;

    void Start()
    {
        //camShake = GameObject.Find("GameManager").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update ()
    {
        //camShake.ShakeCamera(0.1f, 10000000f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour {

    public GameObject groundShake;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ground")
        {
            CameraShake.instance.ShakeCamera(15f, 1f);
            Instantiate(groundShake, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if(col.tag.Contains("Player"))
        {
            CameraShake.instance.ShakeCamera(0.5f, 0.5f);
        }
    }
}

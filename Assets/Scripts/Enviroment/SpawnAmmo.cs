using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour {

    public Transform[] spawnPointAmmo;
    public GameObject AmmoPellet;
    public float DropTimer = 10.0f;
    private int num;
    // Use this for initialization
    void Start () {
        
       

    }
	
	// Update is called once per frame
	void Update () {
        DropTimer -= Time.deltaTime;
       
        if (DropTimer <= 0f)
        {
            num = Random.Range(0, spawnPointAmmo.Length);

            Debug.Log("Spawn");
            Instantiate(AmmoPellet, spawnPointAmmo[num].position, Quaternion.identity);
            DropTimer = 10f; 
        }
        
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    Renderer rend;

	public Material normalMat;
	public Material hitMat;

    public Material criticalHitMat;

	private Material currentMat;

	public float flashTime;

	// Use this for initialization
	void Start () 
	{
       rend = GetComponent<Renderer>();
	   rend.material = normalMat;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SetColourEffect(string hitType)
    {
	    if (hitType == "norm")
            currentMat = hitMat;

        if (hitType == "crit")
            currentMat = criticalHitMat;
    }

    public void ChangeColour()
    {
        rend.material = currentMat;
        Invoke("ResetColour", flashTime);
    }

	public void ResetColour()
    {
    	rend.material = normalMat;
	}
}

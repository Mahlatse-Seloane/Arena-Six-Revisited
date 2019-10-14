using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour {

	public Vector3 minScale;
	public Vector3 maxScale;
	public bool repeatable;
	public float speed = 2f;
	public float duration = 5f;

	public float time1;
	public float time2;
	public int a = 1;
	float i = 0f;
	float rate =0;

	void Start()
	{
		minScale = transform.localScale;
	}
		

	void Update ()
	{
		rate = (1.0f / duration) * speed;
		switch(a)
		{
		case 1:
			if (time1 < 10f) 
			{
				i += Time.deltaTime * rate;
				transform.localScale = Vector3.Lerp (minScale, maxScale, i);
				time1 += Time.deltaTime;
			} 
			else
			{
				a = 2;
			}
			break;
		case 2:
			if (time2 > 0f)
			{
				
				time2 -= Time.deltaTime;
			} 
			else
			{
				a = 3;
				i = 0;
			}
			break;
		case 3:
			if (time1 > 0f) 
			{
				i += Time.deltaTime * rate;
				transform.localScale = Vector3.Lerp (maxScale, minScale, i);
				time1 -= Time.deltaTime;
			} 
			else
			{
				a = 4;
			}
			break;
		case 4:
			if (time2 < 10f) 
			{
				time2 += Time.deltaTime;
			} 
			else
			{
				a = 1;
				i = 0;
			}
			break;
		}
	}
}

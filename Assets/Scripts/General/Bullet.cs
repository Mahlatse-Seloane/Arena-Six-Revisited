using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet: MonoBehaviour {

	public float destroyDelay;
	public float fireSpeed = 30f;

	public GameObject muzzlePrefab;
	public GameObject hitPrefab;

	private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();

		if (muzzlePrefab != null)
		{
			
			var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = gameObject.transform.forward;
			var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();

			if (psMuzzle != null)
			{
				Destroy(muzzleVFX, psMuzzle.main.duration);
			}
			else
			{
				var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(muzzleVFX, psChild.main.duration);
			}
		}

		if (gameObject.tag == "Bullet")
		{
			FindObjectOfType<audioManager> ().Play ("Bullet");
		} 
		else 
		{
			if (gameObject.tag == "Cannon") 
			{
				FindObjectOfType<audioManager> ().Play ("Cannon");
			}
		}

		Destroy (gameObject, destroyDelay);
	}

	void FixedUpdate()
	{
		rb.velocity = transform.forward * fireSpeed;
		rb.freezeRotation = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Wall")
		{
			if (hitPrefab != null)
			{
				Destroy(gameObject);
				var hitVfx = Instantiate(hitPrefab, transform.position, Quaternion.identity);
			}
		}
	}
}

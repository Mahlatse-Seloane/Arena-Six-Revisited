using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

public class Bullet : MonoBehaviour {

	public float destroyDelay;
	public float fireSpeed = 30f;

	public GameObject muzzlePrefab;
	public GameObject hitPrefab;

	private Rigidbody rb;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audioManager.instance.Play("Bullet");

        if (muzzlePrefab != null)
		{
			GameObject muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = gameObject.transform.forward;
			ParticleSystem psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();

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
	}

	void FixedUpdate()
	{
		rb.velocity = transform.forward * fireSpeed;
		Destroy(gameObject, destroyDelay);
	}

    private void Effects(float cameraShakeMag, float duration)
    {
        CameraShake.instance.ShakeCamera(cameraShakeMag, duration);
        Instantiate(hitPrefab, transform.position, Quaternion.identity);
    }

	private void OnCollisionEnter(Collision col)
	{
		if (tag.Contains("Cannon"))
		{
			Effects(10f, 0.5f);
			Destroy(gameObject);
		}
	}
	
    private void OnTriggerEnter(Collider col)
    {
		if (tag == "Bullet")
		{
			Effects(0.5f, 0.5f);
			Destroy(gameObject);
		}
    }
}

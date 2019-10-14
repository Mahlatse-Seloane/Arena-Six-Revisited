using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GunStats
{
	public GameObject chargeParticleEffect;
	public GameObject chargeSound;
	public GameObject bounceBulletPrefab;
	public GameObject chargeBulletPrefab1;
	public GameObject chargeBulletPrefab2;
	public GameObject chargeBulletPrefab3;
	public GameObject chargeBulletPrefab4;
	public GameObject normalBulletPrefab;
	[HideInInspector]public GameObject currentBullet;

    public Transform bulletSpawnPoint;
   
	public float chargeTime;
	public float maxFiredelay;
	[HideInInspector]public float chargeDelay;
	[HideInInspector]public float firedelay;
	public int numberOfBullets;

	public string HeavyFireButton;
	public string FireButton;

	public bool HeavyShotReload = true;
		
    public void SwitchBullet(string bulletType)
	{
        if (bulletType == "normal")
        {
			currentBullet = normalBulletPrefab;
        }
        else if (bulletType == "bouncy")
        {
            currentBullet = bounceBulletPrefab;
        }
        else if (bulletType == "charge1")
        {
            currentBullet = chargeBulletPrefab1;
        }
		else if (bulletType == "charge2")
		{
			currentBullet = chargeBulletPrefab2;
		}
		else if (bulletType == "charge3")
		{
			currentBullet = chargeBulletPrefab3;
		}
		else if (bulletType == "charge4")
		{
			currentBullet = chargeBulletPrefab4;
		}
        else
        {
            Debug.Log("This bullet does not exist");
        }
    }
}

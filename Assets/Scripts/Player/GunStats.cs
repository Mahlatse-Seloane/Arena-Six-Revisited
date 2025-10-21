using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GunStats
{
	[HideInInspector] public GameObject currentBullet;
    public GameObject ChargeBubble, NormalBullet , HeavyShotPrefab;
    private float scaleSpeed = 10f;
    public float ScaleSpeed
    {
        get { return scaleSpeed; }
    }

    public Text ammo;
    public Transform bulletSpawnPoint;
    public Slider ChargeSlider;

	private float maxFiredelay = 0.25f;
    public float MaxFiredelay
    {
        get { return maxFiredelay; }
        set { maxFiredelay = value; }
    }

    public float firedelay { get; set; }
	private int noOfBullets = 40;
	public int NoOfBullets
	{
		get { return noOfBullets; }
		set { noOfBullets = value; }
	}

    private bool heavyShotReloaded = true;
	public bool HeavyShotReloaded 
    {
        get { return heavyShotReloaded; }
        set { heavyShotReloaded = value;  }
    }
	public bool HeavyShotCharging { get; set; }
    public float limit { get; set; }
    private float currentScale;

    public bool Fire { get; set; }


    public void ReloadHeavyShot()
    {
        if (ChargeSlider.value > 0)
        {
            Fire = false;
            ChargeSlider.value -= Time.deltaTime;
            ScaleChargeBubble(ChargeSlider.minValue * 10f);
        }
        else if (!HeavyShotReloaded)
        {
            ChargeBubble.SetActive(false);
            HeavyShotReloaded = true;
            limit = 0f;
        }
    }

    public void ChargingHeavyShot()
    {
        if (heavyShotReloaded && ChargeSlider.value < limit)
        {
            ChargeBubble.SetActive(true);
            ChargeSlider.value += Time.deltaTime;
            ScaleChargeBubble(ChargeSlider.maxValue * 10f);
            Fire = (ChargeSlider.value >= 0.5f);
        }
    }

    public void ScaleChargeBubble(float targetScale)
    {
        currentScale = Mathf.MoveTowards(currentScale, targetScale, scaleSpeed * Time.deltaTime);
        ChargeBubble.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        HeavyShotPrefab.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    public void checkBullets()
    {
        int sector = NoOfBullets / 5;
        limit = (sector < 5) ? sector * 0.5f: ChargeSlider.maxValue;
    }

    public void DecreaseNoOfBullets()
    {
        int a = (int)(ChargeSlider.value / 0.5);
        if (a > 0)
            NoOfBullets -= (5 * a);

        ammo.text = "Ammo: " + NoOfBullets;
    }

    public void reload()
    {
        for (int i = 1; i <= 20 && NoOfBullets < 100; i++)
            NoOfBullets += 1;

        ammo.text = "Ammo: " + NoOfBullets.ToString();
    }

    public void increaseFireTime()
    {
        if (firedelay < 0.5f)
            firedelay += Time.deltaTime;
    }
}

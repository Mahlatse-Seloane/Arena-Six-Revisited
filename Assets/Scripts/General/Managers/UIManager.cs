using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIManager 
{
	public Slider HealthSlider;
	public Slider ChargeSlider;

	public void decreasingHealth(float damage)
	{
		HealthSlider.value = HealthSlider.value - damage;
	}

	public void decreasingHealthCannon(float damage)
	{
		HealthSlider.value = HealthSlider.value - damage;
	}
}

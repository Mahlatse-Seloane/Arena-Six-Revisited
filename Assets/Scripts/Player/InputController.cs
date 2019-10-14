using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
	public UIManager ui;
	public GunStats gun;

	public void HeavyShot()
	{
		if (Input.GetButton (gun.HeavyFireButton) && gun.HeavyShotReload == true)
		{
			ui.ChargeSlider.value += Time.deltaTime;
			gun.chargeDelay += Time.deltaTime;
			//PlayerController.player.currentState = FindObjectOfType<StateManager> ().whichState ("ChargedShot");

			if (ui.ChargeSlider.value == ui.ChargeSlider.maxValue)
			{
				gun.HeavyShotReload = false;
			}
		} 
		else
		{
			if (ui.ChargeSlider.value > 0)
			{
				ui.ChargeSlider.value -= Time.deltaTime;
				if (ui.ChargeSlider.value == 0)
				{
					gun.HeavyShotReload = true;
					gun.chargeDelay = 0f;
				}
			}
		}
	}
}

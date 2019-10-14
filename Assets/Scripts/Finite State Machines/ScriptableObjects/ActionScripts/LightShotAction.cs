using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/LightShotAction")]
public class LightShotAction : Actions
{
	public override void Act(PlayerController controller)
	{
		Shooting (controller);
	}

	public void Shooting(PlayerController controller)
	{
		if ((controller.gun.firedelay > controller.gun.maxFiredelay) && controller.gun.numberOfBullets > 0 && Input.GetButton (controller.gun.FireButton) && !controller.heavyShotCharging) 
		{
			controller.gun.SwitchBullet ("normal");
			Instantiate (controller.gun.currentBullet, controller.gun.bulletSpawnPoint.position, controller.gun.bulletSpawnPoint.rotation);
			controller.gun.numberOfBullets--;
			controller.gun.firedelay = 0f;
		}
	}
}

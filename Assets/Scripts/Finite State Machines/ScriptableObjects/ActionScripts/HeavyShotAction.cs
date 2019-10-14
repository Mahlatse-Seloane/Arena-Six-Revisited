using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/HeavyShotAction")]
public class HeavyShotAction : Actions
{
	public override void Act(PlayerController controller)
	{
		Shooting (controller);
		Rotation(controller);
	}

	public void Shooting(PlayerController controller)
	{
		if (Damage(controller) != 0 && controller.gun.HeavyShotReload == false)
		{
			controller.rb.velocity = new Vector3 (0f, 0f, 0f);
			Instantiate (controller.gun.currentBullet, controller.gun.bulletSpawnPoint.position, controller.gun.bulletSpawnPoint.rotation);
		}
	}

	public void Rotation(PlayerController controller)
	{
		controller.player.playerDirection = Vector3.right * Input.GetAxisRaw (controller.player.HoriMovementForAnalogStick1) + Vector3.forward * -Input.GetAxisRaw (controller.player.VertMovementForAnalogStick1);
		if (controller.player.playerDirection.sqrMagnitude > 0.0f)
		{
			controller.transform.rotation = Quaternion.LookRotation (controller.player.playerDirection, Vector3.up);
		}
	}

	int Damage(PlayerController controller)
	{
		int a = (int)(controller.ui.ChargeSlider.value / 0.5);
		switch(a)
		{
		case 0:
			controller.gun.SwitchBullet ("charge1");

			break;
		case 1:
			controller.gun.SwitchBullet ("charge1");
			Debug.Log ("charge1");
			break;
		case 2:
			controller.gun.SwitchBullet ("charge2");
			Debug.Log ("charge2");
			break;
		case 3:
			controller.gun.SwitchBullet ("charge3");
			Debug.Log ("charge3");
			break;
		case 4:
			controller.gun.SwitchBullet ("charge4");
			Debug.Log ("charge4");
			break;
		}
		return a;
	}
}


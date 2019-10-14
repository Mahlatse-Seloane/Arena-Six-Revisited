using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/AimAssist")]
public class AimAssistAction : Actions
{
	public override void Act(PlayerController controller)
	{
		lookOverThere (controller);
		stopping(controller);
		Rotation(controller);
	}

	public void lookOverThere(PlayerController controller)
	{
		if (EnemyInFieldOfView (controller))
		{
			Vector3 direction = controller.player.enemy.transform.position - controller.transform.position;
			controller.player.targetRotation = Quaternion.LookRotation (direction);
			controller.player.lookAtEmeny = Quaternion.RotateTowards (controller.transform.rotation, controller.player.targetRotation, Time.deltaTime * controller.player.lookSpeed);
			controller.transform.rotation = controller.player.lookAtEmeny;
			controller.player.aimAssist.SetActive (true);
		} 
		else 
		{
			controller.player.aimAssist.SetActive (false);
		}
	}

	bool EnemyInFieldOfView(PlayerController controller)
	{
		Vector3 targetDir = controller.player.enemy.transform.position - controller.transform.position;
		float angle = Vector3.Angle (targetDir, controller.transform.forward);

		if (angle < controller.player.maxAngle)
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	public void stopping(PlayerController controller)
	{
		controller.rb.velocity = new Vector3 (0f, 0f, 0f);
	}

	void Rotation(PlayerController controller)
	{
		controller.player.playerDirection = Vector3.right * Input.GetAxisRaw (controller.player.HoriMovementForAnalogStick1) + Vector3.forward * -Input.GetAxisRaw (controller.player.VertMovementForAnalogStick1);
		if (controller.player.playerDirection.sqrMagnitude > 0.0f)
		{
			controller.transform.rotation = Quaternion.LookRotation (controller.player.playerDirection, Vector3.up);
		}
	}
}

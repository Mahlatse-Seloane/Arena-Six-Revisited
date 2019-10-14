using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Stopping")]
public class StoppingAction : Actions
{
	public override void Act(PlayerController controller)
	{
		stopping(controller);
		Rotation(controller);
	}
		
	public void stopping(PlayerController controller)
	{
		controller.rb.velocity = new Vector3 (0f, 0f, 0f);
	}

	public void Rotation(PlayerController controller)
	{
		controller.player.playerDirection = Vector3.right * Input.GetAxisRaw (controller.player.HoriMovementForAnalogStick1) + Vector3.forward * -Input.GetAxisRaw (controller.player.VertMovementForAnalogStick1);
		if (controller.player.playerDirection.sqrMagnitude > 0.0f)
		{
			controller.transform.rotation = Quaternion.LookRotation (controller.player.playerDirection, Vector3.up);
		}
	}
}

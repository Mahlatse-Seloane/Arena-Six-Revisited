using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Dash")]
public class DashingAction : Actions
{
	public override void Act(PlayerController controller)
	{
		Dash (controller);
		Rotation(controller);
	}

	public void Dash(PlayerController controller)
	{
		float moveHorizontal = Input.GetAxis (controller.player.HoriMovementForAnalogStick1);
		float moveVertical = Input.GetAxis (controller.player.VertMovementForAnalogStick1);

		controller.rb.velocity = new Vector3 (moveHorizontal * controller.player.movespeed, 0f, moveVertical * -controller.player.movespeed);
		Debug.Log ("Dash");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Move")]
public class MoveAction : Actions
{
	public override void Act(PlayerController controller)
	{
		Move (controller);
    }

	public void Move(PlayerController controller)
	{
		controller.rb.velocity = new Vector3 (controller.MoveHorizontal * controller.stats.MoveSpeed, 0f, controller.MoveVertical * -controller.stats.MoveSpeed);
        controller.CheckAmmo(controller.gun.NoOfBullets);
    }
}

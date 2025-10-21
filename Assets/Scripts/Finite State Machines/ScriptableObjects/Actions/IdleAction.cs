using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Idle")]
public class IdleAction : Actions
{
	public override void Act(PlayerController controller)
	{
		Ilde (controller);
	}

	public void Ilde(PlayerController controller)
	{
		controller.rb.velocity = new Vector3 (0f, 0f, 0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Dash")]
public class DashAction : Actions 
{
    public override void Act(PlayerController controller)
    {
        Dash(controller);
    }

    private void Dash(PlayerController controller)
    {
        Move(controller);

        controller.DecreaseDashStamina();
    }

    public void Move(PlayerController controller)
    {
        controller.rb.velocity = new Vector3(controller.MoveHorizontal * controller.stats.DashSpeed, 0f, controller.MoveVertical * -controller.stats.DashSpeed);
    }
}

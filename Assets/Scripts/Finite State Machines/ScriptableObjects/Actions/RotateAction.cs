using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/Rotate")]
public class RotateAction : Actions
{
    public override void Act(PlayerController controller)
    {
        Rotation(controller);
    }

    public void Rotation(PlayerController controller)
    {
        controller.stats.PlayerDirection = Vector3.right * controller.MoveHorizontal + Vector3.forward * -controller.MoveVertical;
        if (controller.stats.PlayerDirection.sqrMagnitude > 0.0f)
            controller.transform.rotation = Quaternion.LookRotation(controller.stats.PlayerDirection, Vector3.up);
    }
}

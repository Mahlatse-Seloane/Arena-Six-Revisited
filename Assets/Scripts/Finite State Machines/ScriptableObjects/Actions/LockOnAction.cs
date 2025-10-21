using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/LockOn")]
public class LockOnAction : Actions
{
    public override void Act(PlayerController controller)
    {
        LockOnOpponent(controller);
    }

    private void LockOnOpponent(PlayerController controller)
    {
        Vector3 targetDir = controller.stats.enemy.transform.position - controller.transform.position;
        float angle = Vector3.Angle(targetDir, controller.transform.forward);

        if (Input.GetKeyDown(controller.lockOnKey) || Input.GetKey(controller.HeavyFireKey))
            controller.anim.SetBool("HeavyShot", true);

        if (Input.GetKey(controller.lockOnKey))
        {
            controller.stats.lockOn.SetActive(angle < 1f);

            if (!controller.LockedOn)
                controller.LockedOn = true;

            if (controller.stats.PlayerDirection.sqrMagnitude <= 0f)
            {
                Vector3 direction = controller.stats.enemy.transform.position - controller.transform.position;
                controller.stats.TargetRotation = Quaternion.LookRotation(direction);
                controller.stats.lookAtEmeny = Quaternion.RotateTowards(controller.transform.rotation, controller.stats.TargetRotation, Time.deltaTime * controller.stats.LookSpeed);
                controller.transform.rotation = controller.stats.lookAtEmeny;
            }

            return;
        }

        if (controller.anim.GetBool("HeavyShot") && (!Input.GetKey(controller.lockOnKey) && !Input.GetKey(controller.HeavyFireKey)))
            controller.anim.SetBool("HeavyShot", false);

        if (controller.LockedOn)
        {
            controller.stats.lockOn.SetActive(false);
            controller.LockedOn = false;
        }
    }
}

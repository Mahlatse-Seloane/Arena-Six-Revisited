using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/Dash")]
public class DashDecision : Decision
{
    public override bool Decide(PlayerController controller)
    {
        return IsPlayerDashing(controller);
    }

    private bool IsPlayerDashing(PlayerController controller)
    {
        if (!controller.Moving || !controller.stats.AllowDash || !Input.GetKey(controller.DashKey))
        {
            if (Input.GetKeyUp(controller.DashKey) || !controller.stats.AllowDash)
                controller.CheckAmmo(controller.gun.NoOfBullets);

            return false;
        }

        if(!controller.DashTrail.activeInHierarchy)
        {
            controller.anim.SetBool("Dash", true);
            controller.sounds[0].SetActive(false);
            controller.sounds[1].SetActive(true);
            controller.DashTrail.SetActive(true);
        }

        return true;
    }
}

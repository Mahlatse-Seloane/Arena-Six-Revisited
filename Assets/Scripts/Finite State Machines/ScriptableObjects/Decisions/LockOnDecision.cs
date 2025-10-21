using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/LockOn")]
public class LockOnDecision : Decision
{
    public override bool Decide(PlayerController controller)
    {
        return aim(controller);
    }

    private bool aim(PlayerController controller)
    {
        if (Input.GetKey(controller.lockOnKey))
        {
            controller.stats.lockOn.SetActive(true);
            return true;
        }

        if (Input.GetKeyUp(controller.lockOnKey))
            controller.stats.lockOn.SetActive(false);

        return false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/Idle")]
public class IdleDecision : Decision
{
    public override bool Decide(PlayerController controller)
    {
        return ShouldPlayerIdle(controller);
    }

    private bool ShouldPlayerIdle(PlayerController controller)
    {
        if (controller.Moving && !Input.GetKey(controller.lockOnKey))
        {
            controller.anim.SetBool("Running", !Input.GetKey(controller.FireKey));

            controller.sounds[0].SetActive(true);
            return false;
        }

        //Idling
        controller.sounds[0].SetActive(false);
        controller.anim.SetBool("Running", false);
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/EarthShatter")]
public class EarthShatterDecision : Decision 
{
    public override bool Decide(PlayerController controller)
    {
        return IsPlayerSlammingGround(controller);
    }

    private bool IsPlayerSlammingGround(PlayerController controller)
    {
        controller.EarthShatter = (controller.EarthShatter || Input.GetKeyDown(controller.EarthShatterKey)) && !controller.LockedOn;
        if (!controller.EarthShatter)
            return false;

        if (controller.EarthShatterDelay <= 0)
        {
            controller.anim.SetBool("EarthShatter", true);
            controller.LightSaber.SetActive(true);
        }

        controller.EarthShatterDelay += Time.deltaTime;
        if (controller.EarthShatterDelay > controller.earthShatterDuration)
        {
            controller.anim.SetBool("EarthShatter", false);
            controller.LightSaber.SetActive(false);
            controller.EarthShatter = false;
            controller.EarthShatterDelay = 0f;
        }

        return true;
    }
}

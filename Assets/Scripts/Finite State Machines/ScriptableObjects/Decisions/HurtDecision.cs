using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/Hurt")]
public class HurtDecision : Decision
{
    public override bool Decide(PlayerController controller)
    {
        return IsPlayerHurt(controller);
    }

    public bool IsPlayerHurt(PlayerController controller)
    {
        if (!controller.stats.Hurt)
            return false;

        controller.HitDelay += Time.deltaTime;
        controller.stats.playerRend.material = controller.stats.hitMat;
        if (controller.HitDelay > controller.stats.flashTime)
        { 
            controller.stats.playerRend.material = controller.stats.normalMat;
            controller.stats.Hurt = false;
            controller.HitDelay = 0f;
        }

        return true;
    }
}

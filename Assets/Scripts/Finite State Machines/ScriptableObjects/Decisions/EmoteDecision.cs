using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Pluggable/Decisions/Emote")]
public class EmoteDecision : Decision
{
    public override bool Decide(PlayerController controller)
    {
        return IsPlayerEmoting(controller);
    }

    private bool IsPlayerEmoting(PlayerController controller)
    {
        controller.Emote = controller.Emote || Input.GetKeyDown(controller.EmoteKey);
        if (!controller.Emote)
            return false;

        if (controller.EmoteDelay <= 0)
            controller.anim.SetBool("Emote", true);

        controller.EmoteDelay += Time.deltaTime;
        if (controller.EmoteDelay > controller.emoteDuration)
        {
            controller.anim.SetBool("Emote", false);
            controller.Emote = false;
            controller.EmoteDelay = 0f;
        }

        return true;
    }
}

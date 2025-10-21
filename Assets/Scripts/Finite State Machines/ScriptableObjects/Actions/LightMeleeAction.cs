using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/LightMeleeAction")]
public class LightMeleeAction : Actions
{
    public override void Act(PlayerController controller)
    {
        if(!Input.GetKey(controller.lockOnKey))
            SwingLightSaber(controller);
    }

    public void SwingLightSaber(PlayerController controller)
    {
        if(!controller.LightMelee && Input.GetKeyDown(controller.LightMeleeKey))
        {
            controller.LightMelee = true;
            controller.LightSaber.SetActive(true);
            audioManager.instance.Play("Sword");
            if (!controller.Moving)
                controller.anim.SetBool("LightMelee", true);

            return;
        }

        if (Input.GetKeyUp(controller.LightMeleeKey))
        {
            controller.LightMelee = false;
            controller.LightSaber.SetActive(false);
            audioManager.instance.StopPlaying("Sword");
            controller.anim.SetBool("LightMelee", false);
        }
    }

    //void HeavyMelee()
    //{
    //    if (Input.GetButtonDown(stats.HeavyMeeleAttack) && !LightMelee && !Shooting) //&& !heavyShotCharging)
    //    {
    //        HeavyHit = true;
    //        LightSaber.SetActive(true);
    //        audioManager.instance.Play("Sword");
    //        anim.SetBool("IsHeavyMelee", true);
    //    }
    //    else if (HeavyMeleeDelay > HeavyMeleeDelayLimit)
    //    {
    //        HeavyHit = false;
    //        HeavyMeleeDelay = 0f;
    //        LightSaber.SetActive(false);
    //        anim.SetBool("IsHeavyMelee", false);
    //    }

    //    if (HeavyHit)
    //        HeavyMeleeDelay += Time.deltaTime;
    //}
}

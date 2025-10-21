using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Actions/LightShot")]
public class LightShotAction : Actions
{
    public override void Act(PlayerController controller)
    {
        Shooting(controller);
    }

    public void Shooting(PlayerController controller)
    {
        if (!Input.GetKey(controller.FireKey))
        {
            if (Input.GetKeyUp(controller.FireKey) || controller.Moving)
            {
                controller.anim.SetBool("Shooting", false);
                controller.anim.SetBool("ShootWhileRunning", false);
            }

            return;
        }

        if (!controller.Moving)
        {
            controller.anim.SetBool("Shooting", true);
            controller.anim.SetBool("ShootWhileRunning", false);
        }
        else
        {
            controller.anim.SetBool("Shooting", false);
            controller.anim.SetBool("ShootWhileRunning", true);
        }

        if (controller.gun.NoOfBullets <= 0)
        {
            audioManager.instance.Play("EmptyClip");
            return;
        }

        if (controller.gun.firedelay > controller.gun.MaxFiredelay)
        {
            Instantiate(controller.gun.NormalBullet, controller.gun.bulletSpawnPoint.position, controller.gun.bulletSpawnPoint.rotation);
            controller.gun.NoOfBullets--;
            controller.gun.firedelay = 0f;

            controller.gun.ammo.text = "Ammo: " + controller.gun.NoOfBullets;
        }

    }
}

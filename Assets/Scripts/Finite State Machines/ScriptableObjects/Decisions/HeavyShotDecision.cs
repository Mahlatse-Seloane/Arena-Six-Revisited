using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/Decisions/HeavyShot")]
public class HeavyShotDecision : Decision 
{
    public override bool Decide(PlayerController controller)
    {
        return IsHeavyShotLoading(controller);
    }

    private bool IsHeavyShotLoading(PlayerController controller)
    {
        if (!controller.gun.HeavyShotReloaded || !Input.GetKey(controller.HeavyFireKey))
        {
            if (!controller.gun.HeavyShotReloaded)
                controller.gun.ReloadHeavyShot();

            if (Input.GetKeyUp(controller.HeavyFireKey))
            {
                controller.gun.HeavyShotReloaded = false;
                audioManager.instance.StopPlaying("Charging");
                audioManager.instance.StopPlaying("Rumble");
                CameraShake.instance.StopCameraShake();

                if (controller.gun.Fire)
                {
                    controller.gun.DecreaseNoOfBullets();
                    Instantiate(controller.gun.HeavyShotPrefab, controller.gun.bulletSpawnPoint.position, controller.gun.bulletSpawnPoint.rotation);
                }
            }

            return false;
        }

        if (controller.gun.NoOfBullets >= 5)
        {
            if (Input.GetKeyDown(controller.HeavyFireKey))
            {
                controller.gun.checkBullets();
                audioManager.instance.Play("Charging");
                audioManager.instance.Play("Rumble");
                CameraShake.instance.ShakeCamera(5f, 99999f);
            }

            controller.gun.ChargingHeavyShot();
        }

        return true;
    }
}

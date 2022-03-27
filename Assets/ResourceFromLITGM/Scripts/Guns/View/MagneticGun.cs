using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class MagneticGun : GunCustom
    {
        public override void Shoot(float angle, Vector3 targetPoint)
        {
            Debug.Log("Shoot");
        }
    }
}
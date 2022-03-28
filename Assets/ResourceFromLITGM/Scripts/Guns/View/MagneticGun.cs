using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class MagneticGun : GunCustom, IMagneticGun
    {
        [SerializeField] private MagneticBullet bullet;  
        [SerializeField] private MagneticConfiguration configuration;
        public override void Shoot(float angle, Vector3 targetPoint)
        {
            var magneticBullet = Instantiate(bullet, targetPoint, Quaternion.identity);
            magneticBullet.Configurate(configuration);
        }
    }
}
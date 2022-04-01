using ServiceLocatorPath;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class MagneticGun : GunCustom, IMagneticGun
    {
        //[SerializeField] private MagneticBullet bullet;  
        [SerializeField] private MagneticConfiguration configuration;
        public override void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult)
        {
            ServiceLocator.Instance.GetService<IAudioManager>().Play(nameOfShootSound);
            var magneticBullet = ServiceLocator.Instance.GetService<IBulletPool>().Spawn<MagneticBullet>(BulletType.Magnetic);
            magneticBullet.transform.position = targetPoint;
            magneticBullet.Configurate(configuration);
        }
    }
}
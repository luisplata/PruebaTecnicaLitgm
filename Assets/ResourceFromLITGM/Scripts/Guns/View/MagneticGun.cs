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
            var magneticBullet = ServiceLocator.Instance.GetService<IBulletPool>().Spawn<MagneticBullet>(BulletType.Magnetic); //Instantiate(bullet, targetPoint, Quaternion.identity);
            magneticBullet.transform.position = targetPoint;
            //magneticBullet.transform.rotation = Quaternion.Euler(rotationBullet);
            magneticBullet.Configurate(configuration);
        }
    }
}
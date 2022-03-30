using ServiceLocatorPath;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class ParabolicGun : GunCustom
    {
        [SerializeField] private ParabolicBullet bullet;
        [SerializeField] private ParabolicConfiguration _configuration;
        public override void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult)
        {
            var parabolicArmo = ServiceLocator.Instance.GetService<IBulletPool>().Spawn<ParabolicBullet>(BulletType.Parabolic);//Instantiate(bullet);
            parabolicArmo.transform.position = pointToSpawn.transform.position;
            var localRotation = pointToSpawn.transform.rotation;
            localRotation.x = 0;
            localRotation.z = 0;
            parabolicArmo.transform.rotation = localRotation;
            //get the angle of the gun
            Debug.Log($"point to spawn {pointToSpawn.transform.position}");
            parabolicArmo.Configure(angle, _configuration, targetPoint);
        }
    }
}
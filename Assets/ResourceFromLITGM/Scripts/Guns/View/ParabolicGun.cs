using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class ParabolicGun : GunCustom
    {
        [SerializeField] private ParabolicArmo armo;
        [SerializeField] private ParabolicConfiguration _configuration;
        public override void Shoot(float angle, Vector3 targetPoint)
        {
            var parabolicArmo = Instantiate(armo);
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
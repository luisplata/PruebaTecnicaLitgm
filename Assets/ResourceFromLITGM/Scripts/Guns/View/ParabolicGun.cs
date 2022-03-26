using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class ParabolicGun : GunCustom
    {
        [SerializeField] private ParabolicArmo armo;
        [SerializeField] private ParabolicConfiguration _configuration;
        public override void Shoot(float angle)
        {
            Debug.Log($"spawn point is {pointToSpawn.transform.localPosition}");
            var rotationLocal = pointToSpawn.transform.rotation;
            rotationLocal.x = 0;
            var parabolicArmo = Instantiate(armo, pointToSpawn.transform.position, rotationLocal);
            //get the angle of the gun
            parabolicArmo.Configure(angle, _configuration);
        }
    }
}
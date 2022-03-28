using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class PortalGun : GunCustom
    {
        
        [SerializeField] private PortalBullet bullet;  
        [SerializeField] private PortalConfiguration configuration;
        private PortalBullet firstPortal, secondPortal;
        public override void Shoot(float angle, Vector3 targetPoint)
        {
            if (firstPortal != null && secondPortal != null) return;
            var portalBullet = Instantiate(bullet, targetPoint, Quaternion.identity);
            //portalBullet.Configurate(configuration);
            if (firstPortal != null)
            {
                firstPortal = portalBullet;
            }else if(secondPortal != null)
            {
                secondPortal = portalBullet;
            }
        }
    }
}
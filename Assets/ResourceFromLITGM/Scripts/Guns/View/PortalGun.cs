using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class PortalGun : GunCustom
    {
        
        [SerializeField] private PortalBullet bullet;  
        [SerializeField] private PortalConfiguration configuration;
        private PortalBullet firstPortal, secondPortal;
        private int indexToPortals;

        protected override void Start()
        {
            base.Start();
            firstPortal = Instantiate(bullet);
            secondPortal = Instantiate(bullet);
            firstPortal.gameObject.SetActive(false);
            secondPortal.gameObject.SetActive(false);
        }

        public override void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet)
        {
            var fromToRotation = Quaternion.FromToRotation(transform.forward, rotationBullet) * transform.rotation;
            if (indexToPortals == 0)
            {
                firstPortal.gameObject.SetActive(true);
                firstPortal.transform.position = targetPoint;
                firstPortal.transform.rotation = fromToRotation;
                firstPortal.transform.rotation = Quaternion.Euler(new Vector3(firstPortal.transform.rotation.eulerAngles.x, firstPortal.transform.rotation.eulerAngles.y, 0));
                indexToPortals++;
            }else if(indexToPortals == 1)
            {
                secondPortal.gameObject.SetActive(true);
                secondPortal.transform.position = targetPoint;
                secondPortal.transform.rotation = fromToRotation;
                secondPortal.transform.rotation = Quaternion.Euler(new Vector3(secondPortal.transform.rotation.eulerAngles.x, secondPortal.transform.rotation.eulerAngles.y, 0));
                indexToPortals = 0;
            }
        }

        protected override void AfterTake()
        {
            base.AfterTake();
            firstPortal.Configure(secondPortal, _player, configuration.RenderTexturePortal2, configuration.RenderTexturePortal1);
            secondPortal.Configure(firstPortal, _player, configuration.RenderTexturePortal1, configuration.RenderTexturePortal2);
        }
    }
}
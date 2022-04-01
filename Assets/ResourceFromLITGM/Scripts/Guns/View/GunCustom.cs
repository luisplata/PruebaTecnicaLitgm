using System;
using System.Collections;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    public abstract class GunCustom : MonoBehaviour, IGunCustom
    {
        [SerializeField] protected GunType id;
        [SerializeField] private float forceToLeaveGun;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider col;
        [SerializeField] private Renderer rend;
        [SerializeField] protected GameObject pointToSpawn;
        [SerializeField] protected string nameOfShootSound;
        [SerializeField] protected float cooldown;
        [SerializeField] private Image imageToCooldown;
        private bool canShot = true;
        protected PlayerEx _player;
        private float _cooldownTimer;

        public GunType Id => id;

        protected virtual void Start()
        {
            Color color = Id switch
            {
                GunType.Magnetic => Color.magenta,
                GunType.Parabolic => Color.blue,
                GunType.Portal => Color.green,
                GunType.Leviosa => Color.red,
                GunType.Cut => Color.yellow,
                _ => Color.cyan
            };

            rend.material.color = color;
            imageToCooldown.color = color;
        }

        public void Take(AnimationsGuns animationsGuns,PlayerEx player)
        {
            ServiceLocator.Instance.GetService<IAudioManager>().Play("Load");
            //tiene que ser hijo de la referencia de la animacion con all en cero para que siga la animacion
            DisableAllComponents();
            animationsGuns.AddGun(this);
            _player = player;
            AfterTake();
        }

        protected virtual void AfterTake(){}

        private void DisableAllComponents()
        {
            rb.isKinematic = true;
            col.enabled = false;
        }

        public virtual void Leave()
        {
            var directionToShootGun = transform.parent.transform.forward;
            rb.isKinematic = false;
            rb.AddForce(directionToShootGun * forceToLeaveGun, ForceMode.Impulse);
            transform.parent = null;
            col.enabled = true;
        }

        public abstract void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult);

        protected IEnumerator Cooldown()
        {
            canShot = false;
            yield return new WaitForSeconds(cooldown);
            canShot = true;
        }

        public bool CanShot()
        {
            return canShot;
        }

        private void Update()
        {
            if (!canShot)
            {
                _cooldownTimer += Time.deltaTime;
                imageToCooldown.fillAmount = _cooldownTimer / cooldown;
                if(_cooldownTimer >= cooldown)
                {
                    _cooldownTimer = 0;
                    canShot = true;
                }
            }
        }

        public void StartCooldown()
        {
            StartCoroutine(Cooldown());
        }
    }
}
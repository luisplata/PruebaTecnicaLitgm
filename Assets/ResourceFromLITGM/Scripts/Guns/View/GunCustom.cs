using System;
using UnityEngine;

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
        protected PlayerEx _player; 

        public GunType Id => id;

        protected virtual void Start()
        {
            var color = Id switch
            {
                GunType.Magnetic =>Color.magenta,
                GunType.Parabolic => Color.blue,
                GunType.Portal => Color.green,
                GunType.Leviosa => Color.red,
                GunType.Cut => Color.yellow,
                _ => Color.cyan
            };

            rend.material.color = color;
        }

        public void Take(AnimationsGuns animationsGuns,PlayerEx player)
        {
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

        public void Leave()
        {
            var directionToShootGun = transform.parent.transform.forward;
            rb.isKinematic = false;
            rb.AddForce(directionToShootGun * forceToLeaveGun, ForceMode.Impulse);
            transform.parent = null;
            col.enabled = true;
        }

        public abstract void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult);
    }
}
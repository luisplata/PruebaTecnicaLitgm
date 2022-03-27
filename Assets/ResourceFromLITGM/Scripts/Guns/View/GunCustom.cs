﻿using System;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    public abstract class GunCustom : MonoBehaviour, IGunCustom
    {
        [SerializeField] protected GunType id;
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider col;
        [SerializeField] private Renderer rend;
        [SerializeField] protected GameObject pointToSpawn;

        public GunType Id => id;

        private void Start()
        {
            var color = Id switch
            {
                GunType.Magnetic =>Color.magenta,
                GunType.Parabolic => Color.blue,
                GunType.Portal => Color.green,
                _ => Color.cyan
            };

            rend.material.color = color;
        }

        public void Take(AnimationsGuns animationsGuns)
        {
            //tiene que ser hijo de la referencia de la animacion con all en cero para que siga la animacion
            DisableAllComponents();
            animationsGuns.AddGun(this);
        }

        private void DisableAllComponents()
        {
            rb.isKinematic = true;
            col.enabled = false;
        }

        public void Leave()
        {
            var directionToShootGun = transform.parent.transform.forward;
            rb.isKinematic = false;
            rb.AddForce(directionToShootGun * _force, ForceMode.Impulse);
            transform.parent = null;
            col.enabled = true;
        }

        public abstract void Shoot(float angle, Vector3 targetPoint);
    }
}
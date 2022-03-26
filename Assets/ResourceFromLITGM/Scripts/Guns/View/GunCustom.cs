using System;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    public abstract class GunCustom : MonoBehaviour, IGunCustom
    {
        [SerializeField] protected GunType id;

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

            GetComponent<Renderer>().material.color = color;
        }

        public void Take()
        {
            Debug.Log($"{name} taken");
            //destroy element and add to inventory
            Destroy(gameObject);
        }
    }
}
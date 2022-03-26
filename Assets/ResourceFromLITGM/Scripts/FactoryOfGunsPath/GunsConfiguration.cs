using System;
using System.Collections.Generic;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.FactoryOfGunsPath
{
    [CreateAssetMenu(menuName = "Custom/Gun configuration")]
    public class GunsConfiguration : ScriptableObject
    {
        [SerializeField] private GunCustom[] guns;
        private Dictionary<GunType, GunCustom> idToGun;

        private void Awake()
        {
            idToGun = new Dictionary<GunType, GunCustom>(guns.Length);
            foreach (var gun in guns)
            {
                idToGun.Add(gun.Id, gun);
            }
        }

        public GunCustom GetGunPrefabById(GunType id)
        {
            if (!idToGun.TryGetValue(id, out var gun))
            {
                throw new Exception($"GunCustom with id {id} does not exit");
            }
            return gun;
        }
    }
}
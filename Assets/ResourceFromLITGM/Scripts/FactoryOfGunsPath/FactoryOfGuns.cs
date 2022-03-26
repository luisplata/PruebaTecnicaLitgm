using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.FactoryOfGunsPath
{
    public class FactoryOfGuns : IFactoryOfGuns
    {

        private readonly GunsConfiguration _gunsConfiguration;

        public FactoryOfGuns(GunsConfiguration gunsConfiguration)
        {
            this._gunsConfiguration = gunsConfiguration;
        }
        
        public GunCustom Create(GunType id)
        {
            var prefab = _gunsConfiguration.GetGunPrefabById(id);

            return Object.Instantiate(prefab);
        }
    }
}
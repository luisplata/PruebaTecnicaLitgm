using ResourceFromLITGM.Scripts.Guns.View;

namespace ResourceFromLITGM.Scripts.FactoryOfGunsPath
{
    public interface IFactoryOfGuns
    {
        GunCustom Create(GunType gunType);
    }
}
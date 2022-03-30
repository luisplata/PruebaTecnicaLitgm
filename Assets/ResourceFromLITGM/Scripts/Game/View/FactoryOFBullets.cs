using UnityEngine;

class FactoryOFBullets : MonoBehaviour, IFactoryOfBullets
{
    public RecyclableObject CreateMagneticBullet(string bullet)
    {
        throw new System.NotImplementedException();
    }

    public RecyclableObject CreateParabolicBullet(string bullet)
    {
        throw new System.NotImplementedException();
    }
}
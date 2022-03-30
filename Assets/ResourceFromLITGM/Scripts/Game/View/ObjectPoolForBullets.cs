using System;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

class ObjectPoolForBullets : MonoBehaviour, IBulletPool
{
    [SerializeField] private MagneticBullet magneticBullet;
    [SerializeField] private ParabolicBullet parabolicBullet;
    private ObjectPool objectPoolMagenitc;
    private ObjectPool objectPoolParabolic;
    public void Configure()
    {
        objectPoolMagenitc = new ObjectPool(magneticBullet, 1);   
        objectPoolParabolic = new ObjectPool(parabolicBullet, 10);   
    }

    public T Spawn<T>(BulletType type)
    {
        return type switch
        {
            BulletType.Magnetic => objectPoolMagenitc.Spawn<T>(),
            BulletType.Parabolic => objectPoolParabolic.Spawn<T>(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
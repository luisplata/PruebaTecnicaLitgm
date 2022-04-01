using System.Collections;
using System.Collections.Generic;
using ResourceFromLITGM.Scripts.Guns.View;
using ServiceLocatorPath;
using UnityEngine;

public class AnimationsGuns : MonoBehaviour
{
    [SerializeField] private GameObject referenceOfAnimation;
    private GunCustom concurrenGun;
    public void AddGun(GunCustom gun)
    {
        if(concurrenGun != null)
        {
            LeaveGun();
        }
        EquipGun(gun);
    }

    private void EquipGun(GunCustom gun)
    {
        Transform transform1;
        (transform1 = gun.transform).SetParent(referenceOfAnimation.transform);
        transform1.localPosition = Vector3.zero;
        transform1.rotation = referenceOfAnimation.transform.rotation;
        transform1.localScale = Vector3.one;
        concurrenGun = gun;
    }

    private void LeaveGun()
    {
        concurrenGun.Leave();
        concurrenGun = null;
    }

    public bool HaveGun()
    {
        return concurrenGun != null;
    }

    public void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult)
    {
        concurrenGun.Shoot(angle, targetPoint, rotationBullet,rayResult);
    }
}

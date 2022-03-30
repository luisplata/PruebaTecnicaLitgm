using System;
using System.Collections;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

class LeviosaGun : GunCustom
{
    [SerializeField] private GameObject bulletPrefab;

    public override void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult)
    {
        //Instantiate(bulletPrefab, targetPoint, Quaternion.identity);
        Physics.gravity = new Vector3(-9.81f, 0, 0);
    }

}

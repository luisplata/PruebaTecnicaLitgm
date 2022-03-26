using System;
using System.Collections;
using System.Collections.Generic;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

public class PlayerEx : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private AnimationsGuns animationsGuns;
    private Transform camTransform;

    public void ClickToTakeGun()
    {
        Debug.DrawRay(camTransform.position, camTransform.forward * 100, Color.red);
        if(Physics.Raycast (camTransform.position, camTransform.forward, out var hit, 100)) {
            if(hit.transform.GetComponent<GunCustom>()) {
                hit.transform.GetComponent<GunCustom>().Take(animationsGuns);
                return;
            }
        }
        if(animationsGuns.HaveGun())
        {
            //gun will shooting
            float angle = Vector3.Angle(camTransform.forward, transform.forward);
            Debug.Log($"Shoot {angle}");
            //Debug.Log("shooting");
            animationsGuns.Shoot(angle);
        }
    }

    public void Configure()
    {
        camTransform = cam.transform;
    }
}

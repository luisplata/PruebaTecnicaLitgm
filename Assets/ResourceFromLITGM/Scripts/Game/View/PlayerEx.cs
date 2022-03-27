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
            Vector3 target;
            if(Physics.Raycast (camTransform.position, camTransform.forward, out var targetHit, 100)) {
                Debug.Log($"info {targetHit.point}");
                target = targetHit.point;
            }else
            {
                //Debug.Log($"target with not hit {transform.forward + new Vector3(0, 0, 10)}");
                target = transform.position + transform.forward * 10;
            }
            //Debug.Log($"Shoot {angle}");
            //Debug.Log("shooting");
            animationsGuns.Shoot(angle, target);
        }
    }

    public void Configure()
    {
        camTransform = cam.transform;
    }
}

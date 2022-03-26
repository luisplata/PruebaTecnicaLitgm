using System;
using System.Collections;
using System.Collections.Generic;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

public class PlayerEx : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Transform camTransform;

    public void ClickToTakeGun()
    {
        Debug.DrawRay(camTransform.position, camTransform.forward * 100, Color.red);
        if(Physics.Raycast (transform.position, transform.forward, out var hit, 100)) {
            if(hit.transform.GetComponent<GunCustom>()) {
                hit.transform.GetComponent<GunCustom>().Take();
            }
        } 
    }

    public void Configure()
    {
        camTransform = cam.transform;
    }
}

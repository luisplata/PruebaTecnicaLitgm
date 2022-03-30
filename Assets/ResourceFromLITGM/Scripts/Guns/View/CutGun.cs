using System.Collections.Generic;
using EzySlice;
using ResourceFromLITGM.Scripts.Guns.View;
using UnityEngine;

class CutGun:GunCustom
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CutElement elQueCorta;
    [SerializeField] private List<string> tagsForbidden;
    private Material materialDelQueCorta;
    private GameObject elCortado;
    private int shootHashCode = Animator.StringToHash("shoot");

    public override void Shoot(float angle, Vector3 targetPoint, Vector3 rotationBullet, GameObject rayResult)
    {
        _animator.SetTrigger(shootHashCode);
        if (rayResult == null) return;
        foreach (var tag in tagsForbidden)
        {
            if (rayResult.CompareTag(tag))
            {
                return;
            }
        }
        //_animator.SetTrigger("shoot");
        materialDelQueCorta = rayResult.GetComponent<Renderer>().material;
        var slicedHull = rayResult.Slice(targetPoint, transform.up, materialDelQueCorta);
        GameObject kesile = slicedHull.CreateUpperHull(rayResult,materialDelQueCorta);
        kesile.AddComponent<MeshCollider>().convex = true;
        var rb = kesile.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        kesile.AddComponent<BoxCollider>();
        kesile.tag = "Cut";

        GameObject kesiledown = slicedHull.CreateLowerHull(rayResult,materialDelQueCorta);
        kesiledown.AddComponent<MeshCollider>().convex = true;
        var rbL = kesiledown.AddComponent<Rigidbody>();
        rbL.useGravity = true;
        rbL.isKinematic = false;
        rbL.AddForce(kesiledown.transform.forward * 10, ForceMode.Impulse);
        kesiledown.AddComponent<BoxCollider>();
        kesiledown.tag = "Cut";

        Destroy(rayResult);
        
    }

    protected override void AfterTake()
    {
        base.AfterTake();
        _animator.SetBool("equip", true);
    }
}
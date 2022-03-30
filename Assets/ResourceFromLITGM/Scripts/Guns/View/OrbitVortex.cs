using System;
using UnityEngine;

public class OrbitVortex : MonoBehaviour
{
    private Transform _target;
    private bool canVortex;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void Update()
    {
        if(!canVortex) return;
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime);
    }

    public void Configure(Transform target)
    {
        _target = target;
        canVortex = true;
    }

    public void Release()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        Destroy(this);
    }
}
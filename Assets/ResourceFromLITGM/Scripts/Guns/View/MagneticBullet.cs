using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBullet : RecyclableObject
{
    [SerializeField] private List<GameObject> pointToVortex;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private CollisionMageneticBullet _collisionMageneticBullet;
    [SerializeField] private Animator _animator;
    private GameObject[] _vortex;
    private int indexVortex;
    private bool canVortex;
    private List<OrbitVortex> _listObjects;
    private MagneticConfiguration _configuration;

    public void Configurate(MagneticConfiguration config)
    {
        _configuration = config;
        _collider.radius = _configuration.Radius;
        _collider.enabled = true;
        _collisionMageneticBullet.onCollisionEnterInBullet += OnCollisionEnterInBullet;
        _animator.SetTrigger("open");
        _vortex = new GameObject[pointToVortex.Count - 1];
        _listObjects = new List<OrbitVortex>();
        StartCoroutine(Rotating());
        
        Invoke(nameof(Recycle), _configuration.TimeToEffect);
    }

    private IEnumerator Rotating()
    {
        yield return new WaitForSeconds(_configuration.TimeToActivateEffect);
        _animator.SetTrigger("start");
    }

    private void OnCollisionEnterInBullet(Collider collision)
    {
        if (indexVortex >= pointToVortex.Count - 1 || collision.gameObject.TryGetComponent<OrbitVortex>(out var orbitVortex)) return;
        //Debug.Log($"name {collision.name}");
        _vortex[indexVortex] = collision.gameObject;
        indexVortex++;
        canVortex = true;
        var vortex = collision.gameObject.AddComponent<OrbitVortex>();
        vortex.Configure(pointToVortex[indexVortex].transform);
        _listObjects.Add(vortex);
    }

    internal override void Init()
    {
    }

    internal override void Release()
    {
        foreach (var vortex in _listObjects)
        {
            vortex.Release();
        }
        _vortex = new GameObject[pointToVortex.Count - 1];
        _listObjects = new List<OrbitVortex>();
        _animator.SetTrigger("close");
        indexVortex = 0;
    }
}
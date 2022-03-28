using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBullet : MonoBehaviour
{
    [SerializeField] private List<GameObject> pointToVortex;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private CollisionMageneticBullet _collisionMageneticBullet;
    [SerializeField] private Animator _animator;
    private GameObject[] _vortex;
    private int indexVortex;
    private bool canVortex;

    public void Configurate(MagneticConfiguration config)
    {
        _collider.radius = config.Radius;
        _collider.enabled = true;
        _collisionMageneticBullet.onCollisionEnterInBullet += OnCollisionEnterInBullet;
        _animator.SetTrigger("open");
        _vortex = new GameObject[pointToVortex.Count - 1];
        StartCoroutine(Rotating());
    }

    private IEnumerator Rotating()
    {
        yield return new WaitForSeconds(.2f);
        _animator.SetTrigger("start");
    }

    private void OnCollisionEnterInBullet(Collider collision)
    {
        if (indexVortex >= pointToVortex.Count - 1 || _vortex[indexVortex] != null) return;
        Debug.Log($"name {collision.name}");
        _vortex[indexVortex] = collision.gameObject;
        indexVortex++;
        canVortex = true;
        if (collision.gameObject.TryGetComponent<OrbitVortex>(out var orbitVortex)) return;
        var vortex = collision.gameObject.AddComponent<OrbitVortex>();
        vortex.Configure(pointToVortex[indexVortex].transform);
    }

}
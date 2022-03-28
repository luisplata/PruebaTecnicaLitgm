using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMageneticBullet : MonoBehaviour
{
    public delegate void OnCollisionEnterInBullet(Collider collision);

    public OnCollisionEnterInBullet onCollisionEnterInBullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Build") || other.CompareTag("Player") || other.CompareTag("Bullet")) return;
        onCollisionEnterInBullet?.Invoke(other);
    }
}

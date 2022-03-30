using System;
using UnityEngine;

public class LeviosaBullet : MonoBehaviour
{
    private GameObject target;
    private bool canLeviosa;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Build") || !collision.collider.CompareTag("Bullet") ||
            !collision.collider.CompareTag("Wall") || !collision.collider.CompareTag("Portal"))
        {
            target = collision.gameObject;
            canLeviosa = true;   
        }
    }

    private void Update()
    {
        if (!canLeviosa) return;
        Debug.Log("leviosa");
        target.transform.position = Vector3.MoveTowards(transform.position, Vector3.up * 5, Time.deltaTime * 10);
    }
}
using UnityEngine;

public class OrbitVortex : MonoBehaviour
{
    private Transform _target;
    private bool canVortex;

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
}
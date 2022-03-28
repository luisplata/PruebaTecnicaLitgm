using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Portal configuration")]
public class PortalConfiguration : ScriptableObject
{
    [SerializeField]private float radius;
    public float Radius => radius;
}
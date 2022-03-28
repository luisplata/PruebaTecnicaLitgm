using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Magnetic configuration")]
public class MagneticConfiguration : ScriptableObject
{
    [SerializeField]private float radius;
    public float Radius => radius;
}
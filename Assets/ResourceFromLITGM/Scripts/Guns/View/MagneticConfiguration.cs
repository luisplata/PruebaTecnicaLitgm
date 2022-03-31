using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Magnetic configuration")]
public class MagneticConfiguration : ScriptableObject
{
    [SerializeField]private float radius;
    [SerializeField] private float timeToEffect;
    [SerializeField] private float timeToActivateEffect;
    public float Radius => radius;
    public float TimeToEffect => timeToEffect;
    public float TimeToActivateEffect => timeToActivateEffect;
}
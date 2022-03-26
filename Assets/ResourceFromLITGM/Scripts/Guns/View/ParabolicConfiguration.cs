using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    [CreateAssetMenu(menuName = "Custom/Parabolic configuration")]
    public class ParabolicConfiguration : ScriptableObject
    {
        [SerializeField] private float forceOfLaunch;
        
        public float ForceOfLaunch => forceOfLaunch;
        
    }
}
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    [CreateAssetMenu(menuName = "Custom/Parabolic configuration")]
    public class ParabolicConfiguration : ScriptableObject
    {
        [SerializeField] private float forceOfLaunch;
        [SerializeField] private float heightOfLaunch;
        
        public float ForceOfLaunch => forceOfLaunch;
        public float HeightOfLaunch => heightOfLaunch;
        
    }
}
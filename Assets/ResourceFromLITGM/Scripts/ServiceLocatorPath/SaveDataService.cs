using UnityEngine;

namespace ServiceLocatorPath
{
    public class SaveDataService : ISaveDataService
    {
        private string animationShow;
        public void SaveAnimation(string nameOfAnimation)
        {
            animationShow = nameOfAnimation;
        }
        
        public string GetAnimation()
        {
            return animationShow;
        }
    }
}

using ResourceFromLITGM.Scripts.Game.View;
using ServiceLocatorPath;

namespace ResourceFromLITGM.Scripts.Game.Model
{
    public class AnimationsInGame : IAnimationInGame
    {
        private readonly IRulesOfAnimationInGame _rules;

        public AnimationsInGame(IRulesOfAnimationInGame rules)
        {
            _rules = rules;
            StartAnimationSelected();
        }

        private void StartAnimationSelected()
        {
            var animation = ServiceLocator.Instance.GetService<ISaveDataService>().GetAnimation();
            _rules.StartAnimation(animation);
        }
    }
}
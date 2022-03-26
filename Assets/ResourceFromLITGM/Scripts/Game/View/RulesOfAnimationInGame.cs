using ResourceFromLITGM.Scripts.Game.Model;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Game.View
{
    public class RulesOfAnimationInGame : MonoBehaviour, IRulesOfAnimationInGame
    {
        [SerializeField] private Animator _animator;
        private AnimationsInGame _animationsInGame;
        private void Start()
        {
            _animationsInGame = new AnimationsInGame(this);
        }

        public void StartAnimation(string animation)
        {
            _animator.SetBool("animation", true);
            _animator.SetTrigger(animation);
        }
    }
}
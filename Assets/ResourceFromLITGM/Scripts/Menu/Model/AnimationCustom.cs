//Class for controller animations

using ServiceLocatorPath;

public class AnimationCustom: IAnimationCustom 
{
    private IAnimationController _animationController;
    
    public AnimationCustom(IAnimationController animationController)
    {
        _animationController = animationController;
    }

    public void PlayAnimation(string nameOfAnimation)
    {
        ServiceLocator.Instance.GetService<ISaveDataService>().SaveAnimation(nameOfAnimation);
        _animationController.PlayAnimation(nameOfAnimation);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationsController : MonoBehaviour, IAnimationController
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Animator animator;
    private IAnimationCustom anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = new AnimationCustom(this);
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => ChangeButtonColor(button));
        }
        buttons[0].onClick.Invoke();
    }

    public void StartAnimationFromButton(string nameOfAnimation)
    {
        anim.PlayAnimation(nameOfAnimation);
    }

    private void ChangeButtonColor(Button button)
    {
        foreach (var buttonLocal in buttons)
        {
            buttonLocal.GetComponent<Image>().color = Color.white;
        }
        button.GetComponent<Image>().color = Color.red;
    }

    public void PlayAnimation(string nameOfAnimation)
    {
        StartCoroutine(StartAnimation(nameOfAnimation));
    }
    
    private IEnumerator StartAnimation(string nameOfAnimation)
    {
        animator.SetBool("animation", false);
        yield return new WaitForSeconds(.1f);
        animator.SetBool("animation", true);
        animator.SetTrigger(nameOfAnimation);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
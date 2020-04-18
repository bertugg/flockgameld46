using UnityEngine;
using UnityEngine.Events;

public class FadeController : MonoBehaviour
{
    protected Animator animator;
    public UnityEvent onFadeInComplete, onFadeOutComplete;
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
        GameManager.Instance.fadeController = this;
    }

    public void PlayFadeIn(bool invokeEvent = false)
    {
        if(invokeEvent)
            animator.SetTrigger("FadeInWEvent");
        else
            animator.SetTrigger("FadeIn");
    }

    public void PlayFadeOut(bool invokeEvent = false)
    {
        if(invokeEvent)
            animator.SetTrigger("FadeOutWEvent");
        else
            animator.SetTrigger("FadeOut");
    }
    
    public void PlayFadeInOut(bool invokeEvent = false) // Invokes the Fadeout Event in between
    {
        if(invokeEvent)
            animator.SetTrigger("FadeInOutWEvent");
        else
            animator.SetTrigger("FadeInOut");
    }

    public void OnFadeInComplete()
    {
        onFadeInComplete.Invoke();
    }

    public void OnFadeOutComplete()
    {
        onFadeOutComplete.Invoke();
    }

}
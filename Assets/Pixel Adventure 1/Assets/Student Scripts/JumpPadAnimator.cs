using UnityEngine;

public class JumpPadAnimator : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayBounceAnimation()
    {
        anim.ResetTrigger("Bounce");
        anim.SetTrigger("Bounce");
    }

}

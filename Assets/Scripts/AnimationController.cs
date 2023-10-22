using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    [HideInInspector] public Animator _anim;
    public UnityEvent<string> OnAnimationFinished;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void ChangeWalkingAnimation(Vector2 Direction)
    {
        if ((_anim.GetInteger("Drown") == 0) && (_anim.GetInteger("GetHurt") == 0))
        {
            _anim.SetFloat("Horizontal", Direction.x);
            _anim.SetFloat("Vertical", Direction.y);
            _anim.SetFloat("TransitionFactor", Direction.magnitude);
        }
        else
        {
            _anim.SetFloat("Horizontal", 0);
            _anim.SetFloat("Vertical", 0);
            _anim.SetFloat("TransitionFactor", 0);
        }
        ChangeAnimSpeed(1f);
    }

    public void ChangeAnimSpeed(float speed)
    {
        _anim.speed = speed;
    }

    public void ThrowGranadeAnim(int value)
    {
        if (_anim.GetInteger("Drown") == 0)
        {
            _anim.SetInteger("ThrowGranade", value);
        }
        else
        {
            _anim.SetInteger("ThrowGranade", 0);
        }
    }

    public void GetHurtAnimation(int value)
    {
        if (_anim.GetInteger("Drown") == 0)
        {
            _anim.SetInteger("GetHurt", value);
            ChangeAnimSpeed(value);
        }
        else{
            _anim.SetInteger("GetHurt", 0);
        }
    }

    public void DrowningAnimation(int value)
    {
        _anim.SetInteger("Drown", value);
        ChangeAnimSpeed(value);
    }

    public void CheckAnimFinished(AnimationClip animClip)
    {
        StartCoroutine(AnimFinishedCheker(animClip));
    }

    IEnumerator AnimFinishedCheker(AnimationClip animClip)
    {
        float animSpeed = _anim.GetCurrentAnimatorStateInfo(0).speed;
        float animDuration = animClip.length * (1 / animSpeed);
        yield return new WaitForSeconds(animDuration);

        OnAnimationFinished.Invoke(animClip.name);
    }
}
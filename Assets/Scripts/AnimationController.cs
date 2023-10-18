using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator _anim;

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

    private AnimationClip getAnim(AnimatorClipInfo[] animatiorClipInfoList, string name)
    {
        AnimationClip clip = null;
        foreach (AnimatorClipInfo anim in animatiorClipInfoList)
        {
            if (anim.clip.name != name) continue;

            clip = anim.clip;
            break;
        }

        return clip;
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
        }
        else{
            _anim.SetInteger("GetHurt", 0);
        }
    }

    public void DrowningAnimation(int value)
    {
        _anim.SetInteger("Drown", value);
    }
}
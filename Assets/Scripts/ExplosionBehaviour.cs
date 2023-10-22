using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] private AnimationClip explosionAnimClip;
    private AnimationController AC;

    private void Awake()
    {
        AC = GetComponent<AnimationController>();
        AC.OnAnimationFinished.AddListener(OnAnimationFinished);
    }

    public void CheckExploded()
    {
        AC.CheckAnimFinished(explosionAnimClip);
    }

    private void OnAnimationFinished(string name)
    {
        if (name == "Explosion")
        {
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(GhostAnimation))]
public class Ghost : MonoBehaviour
{
    private DoTweenAnimationBase _animation;

    private void Start()
    {
        _animation = GetComponent<GhostAnimation>();
        _animation.OnAnimationEnd += SelfDestroy;
        _animation.Play();
    }

    private void SelfDestroy()
    {
        _animation.OnAnimationEnd -= SelfDestroy;
        Destroy(gameObject);
    }
}


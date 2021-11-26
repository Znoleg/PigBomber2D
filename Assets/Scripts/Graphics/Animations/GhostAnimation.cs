using DG.Tweening;
using System.Linq;
using UnityEngine;

public class GhostAnimation : DoTweenAnimationBase
{
    protected override Sequence CreateActivationSequence()
    {
        return DOTween.Sequence()
            .Append(transform.DOShakePosition(AnimationTime, new Vector3(0.65f, 0f, 0f), 2, 45))
            .Join(transform.DOMoveY(transform.position.y + 10f, AnimationTime));
    }
}


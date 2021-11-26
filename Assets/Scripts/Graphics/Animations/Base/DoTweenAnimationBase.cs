using DG.Tweening;
using System;
using UnityEngine;

public abstract class DoTweenAnimationBase : AnimationBase
{
    [SerializeField]
    private Ease _ease = Ease.Linear;

    [SerializeField]
    private bool _canInterrupt;

    public override event Action OnAnimationEnd;

    protected Sequence AnimationSequence { get; private set; }
    private bool IsSequenceCreated =>
        AnimationSequence != null && AnimationSequence.IsActive();

    public override void Play(int loops = 1)
    {
        if (!_canInterrupt) CheckInterruption(nameof(Play));

        AnimationSequence = CreateSequenceParameterized(loops);
        AnimationSequence.Play();
    }

    protected virtual void Awake()
    {
        DOTween.Init();
        DOTween.defaultAutoPlay = AutoPlay.None;
    }

    protected virtual void OnDestroy()
    {
        AnimationSequence.Kill(false);
    }

    protected abstract Sequence CreateActivationSequence();

    private void CheckInterruption(string methodName)
    {
        if (IsSequenceCreated &&
            AnimationSequence.IsPlaying())
        {
            throw new InvalidOperationException($"Trying to " +
                $"interrupt playing animation at {methodName} " +
                $"in {GetType().Name} of {gameObject.name}");
        }
    }

    private Sequence CreateSequenceParameterized(int loops)
        => CreateActivationSequence()
            .SetEase(_ease)
            .SetLoops(loops)
            .OnComplete(() => OnAnimationEnd?.Invoke());
}
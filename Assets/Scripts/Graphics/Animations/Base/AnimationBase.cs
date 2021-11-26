using System;
using UnityEngine;

public abstract class AnimationBase : MonoBehaviour
{
    [SerializeField] private float _animationTime;

    public float AnimationTime => _animationTime;
    public abstract event Action OnAnimationEnd;

    public abstract void Play(int loops = 1);
}
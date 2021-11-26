using System;
using UnityEngine;

public abstract class InputReciever : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    
    public event Action OnBombKeyPressed;

    protected virtual void Update()
    {
        MoveInput = GetMove();
    }

    protected abstract Vector2 GetMove();
    protected void InvokeBombKeyPressed()
        => OnBombKeyPressed?.Invoke();
}

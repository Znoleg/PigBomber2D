using UnityEngine;
using System;

public abstract class Obstacle : MonoBehaviour
{
    public bool IsHitable => Hitable != null;
    protected abstract IHitable Hitable { get; }

    public IHitable GetHitable()
    {
        if (!IsHitable)
            throw new InvalidOperationException($"Can't " +
                $"get {nameof(IHitable)} of unhitalbe {GetType().Name} " +
                $"{gameObject.name}");
        return Hitable;
    }
}


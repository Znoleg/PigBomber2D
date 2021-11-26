using System;
using UnityEngine;

public enum MoveDirection
{
    Left, Right, Up, Down, None
}

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField]
    private MovementSettings _movementSettings;

    public event Action OnBombSetSignal;
    protected MovementSettings MovementSettings => _movementSettings;

    public abstract MoveDirection Move(IMovementStats movementStats);

    protected MoveDirection GetMoveDirection(Vector2 movement)
    {
        if (movement == Vector2.zero) return MoveDirection.None;
        
        bool isMovingHorizontally = Mathf.Abs(movement.x) > Mathf.Abs(movement.y);
        if (isMovingHorizontally)
        {
            if (movement.x > 0) return MoveDirection.Right;
            return MoveDirection.Left;
        }
        
        if (movement.y > 0) return MoveDirection.Up;
        return MoveDirection.Down;
    }

    protected void InvokeBombSignal()
        => OnBombSetSignal?.Invoke();
}


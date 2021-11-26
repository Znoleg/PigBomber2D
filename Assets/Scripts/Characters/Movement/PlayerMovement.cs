using UnityEngine;

public class PlayerMovement : MovementBase
{
    [SerializeField]
    private InputReciever _inputReciever;

    public override MoveDirection Move(IMovementStats movementStats)
    {
        Vector2 input = _inputReciever.MoveInput;
        Vector2 movement = input * movementStats.MoveSpeed * Time.deltaTime;
        movement += MovementSettings.GetAdditionalMovement(movement);

        transform.Translate(movement);

        return GetMoveDirection(input);
    }

    protected virtual void Awake()
    {
        _inputReciever.OnBombKeyPressed += InvokeBombSignal;
    }

    protected virtual void OnDestroy()
    {
        _inputReciever.OnBombKeyPressed -= InvokeBombSignal;
    }
}

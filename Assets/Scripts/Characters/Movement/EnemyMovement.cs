using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class FloatRange
{
    public float min;
    public float max;
}

[RequireComponent(typeof(AIDestinationSetter), typeof(AIPath))]
public class EnemyMovement : MovementBase
{
    [SerializeField]
    private GameGrid _gameGrid;

    [SerializeField]
    private Transform _aiTarget;

    [SerializeField]
    private bool _canPlantBombs;

    [SerializeField]
    private FloatRange _plantCooldown;

    private AIPath _aiPath;
    private List<Vector2> _freeCellPositions;
    private Vector2 _prevPosition = Vector2.zero;

    public override MoveDirection Move(IMovementStats movementStats)
    {
        _aiPath.maxSpeed = movementStats.MoveSpeed;
        if (Vector2.Distance(transform.position, _aiTarget.position) <= 0.1f)
        {
            _aiTarget.position = GetNewTarget();
        }

        Vector2 movement = (Vector2)transform.position - _prevPosition;
        _prevPosition = transform.position;
        return GetMoveDirection(movement);
    }

    private void StartBombCountdown()
    {
        float cooldownTime = Random.Range(_plantCooldown.min, _plantCooldown.max);
        Invoke(nameof(InvokeBombSignal), cooldownTime);
        Invoke(nameof(StartBombCountdown), cooldownTime);
    }

    private Vector2 GetNewTarget()
    {
        return _freeCellPositions[Random.Range(0, _freeCellPositions.Count)];
    }

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
    }

    private void Start()
    {
       _freeCellPositions = _gameGrid.FreePositions;
        _aiTarget.position = GetNewTarget();
        if (_canPlantBombs) StartBombCountdown();
    }
}


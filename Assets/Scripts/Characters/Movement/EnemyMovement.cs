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
    private List<Vector2> _freePositions;
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
        float time = Random.Range(_plantCooldown.min, _plantCooldown.max);
        Invoke(nameof(InvokeBombSignal), time);
        Invoke(nameof(StartBombCountdown), time);
    }

    private Vector2 GetNewTarget()
    {
        return _freePositions[Random.Range(0, _freePositions.Count)];
    }

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
    }

    private void Start()
    {
       _freePositions = _gameGrid.FreePositions;
        _aiTarget.position = GetNewTarget();
        if (_canPlantBombs) StartBombCountdown();
    }
}


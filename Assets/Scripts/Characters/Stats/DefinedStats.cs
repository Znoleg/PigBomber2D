using UnityEngine;

/// <summary>
/// Define stats in inspector. Can be used for enemy
/// </summary>
public class DefinedStats : CharacterStatsBase
{
    [SerializeField] [Range(1.5f, 5f)]
    private float _bombCountdown = 5f;

    [SerializeField] [Range(1, 5)]
    private uint _maxBombCount = 1;

    [SerializeField] [Range(3, 10)]
    private uint _bombRange = 3;

    [SerializeField] [Range(1f, 5f)]
    private float _moveSpeed = 3f;

    public override float BombCountdown => _bombCountdown;
    public override uint BombFireRange => _bombRange;
    public override uint MaxBombCount => _maxBombCount;
    public override float MoveSpeed => _moveSpeed;
}


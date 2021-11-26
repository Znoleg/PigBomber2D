using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    BombBlowCountdown, MaxBombCount, BombRange, MoveSpeed
}

public abstract class CharacterStatsBase : MonoBehaviour, IBombStats,
    IMovementStats
{
    public abstract float BombCountdown { get; }
    public abstract uint BombFireRange { get; }
    public abstract float MoveSpeed { get; }
    public abstract uint MaxBombCount { get; }
}


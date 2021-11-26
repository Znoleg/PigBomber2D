using System;
using System.Collections.Generic;

/// <summary>
/// Stats that can be changed by picking bonuses. Can be used for player
/// </summary>
public class ChangableStats : DefinedStats
{
    private readonly Dictionary<StatType, float> _statValues
        = new Dictionary<StatType, float>();

    private readonly Dictionary<StatType, StatLevel> _statLevels
        = new Dictionary<StatType, StatLevel>();

    private const StatLevel _finalLevel = StatLevel.Level5;

    public override float BombCountdown => _statValues[StatType.BombBlowCountdown];
    public override uint BombFireRange => (uint)_statValues[StatType.BombRange];
    public override uint MaxBombCount => (uint)_statValues[StatType.MaxBombCount];
    public override float MoveSpeed => _statValues[StatType.MoveSpeed];
    

    public bool TryUpgradeStat(StatType statType, float statDelta)
    {
        if (_statLevels[statType] == _finalLevel) return false;
        _statValues[statType] += statDelta;
        return true;
    }

    protected virtual void Awake()
    {
        _statValues.Add(StatType.BombBlowCountdown, base.BombCountdown);
        _statValues.Add(StatType.MaxBombCount, base.MaxBombCount);
        _statValues.Add(StatType.BombRange, base.BombFireRange);
        _statValues.Add(StatType.MoveSpeed, base.MoveSpeed);

        var allStats = (StatType[])Enum.GetValues(typeof(StatType));
        foreach (StatType statType in allStats)
        {
            _statLevels.Add(statType, StatLevel.Level1);
        }
    }
}


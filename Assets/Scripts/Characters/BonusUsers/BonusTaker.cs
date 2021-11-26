using UnityEngine;

[RequireComponent(typeof(ChangableStats))]
public class BonusTaker : BonusUser
{
    private ChangableStats _changableStats;

    public override void InteractWithBonus(Bonus bonus)
    {
        _changableStats.TryUpgradeStat(bonus.ChangableStat,
            bonus.ChangeValue);
        bonus.Destroy();
    }

    private void Awake()
    {
        _changableStats = GetComponent<ChangableStats>();
    }
}


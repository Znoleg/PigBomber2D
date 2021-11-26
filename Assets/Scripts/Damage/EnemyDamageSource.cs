using UnityEngine;

public class EnemyDamageSource : DamageSource // I don't like this system but it saves time.
{
    [SerializeField]
    private CharacterDeath _player;

    private IHitable _playersHitable;

    protected override bool CheckHitConditions(IHitable hitable)
    {
        return hitable.Equals(_playersHitable);
    }

    protected override void Awake()
    {
        base.Awake();
        _playersHitable = _player;
    }
}


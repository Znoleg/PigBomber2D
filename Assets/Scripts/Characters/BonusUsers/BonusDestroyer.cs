/// <summary>
/// Destroys the bonuses. Can be used by enemy
/// </summary>
public class BonusDestroyer : BonusUser
{
    protected override void InteractWithBonus(Bonus bonus)
    {
        bonus.Destroy();
    }
}


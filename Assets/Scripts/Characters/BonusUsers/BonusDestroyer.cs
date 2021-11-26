/// <summary>
/// Destroys the bonuses. Can be used by enemy
/// </summary>
public class BonusDestroyer : BonusUser
{
    public override void InteractWithBonus(Bonus bonus)
    {
        bonus.Destroy();
    }
}


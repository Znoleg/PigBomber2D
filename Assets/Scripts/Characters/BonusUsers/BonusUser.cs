using UnityEngine;

public abstract class BonusUser : MonoBehaviour
{
    public abstract void InteractWithBonus(Bonus bonus);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bonus bonus))
        {
            InteractWithBonus(bonus);
        }
    }
}


using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class DamageSource : MonoBehaviour
{
    protected abstract bool CheckHitConditions(IHitable hitable);

    protected virtual void Awake()
    {
        var triggerCollider = GetComponent<Collider2D>();
        if (!triggerCollider.isTrigger)
        {
            Debug.LogError($"{gameObject.name} collider " +
                $"must be trigger");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHitable hitable))
        {
            if (CheckHitConditions(hitable))
            {
                hitable.GetHit();
            }
        }
    }
}


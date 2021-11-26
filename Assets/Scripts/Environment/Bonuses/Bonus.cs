using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bonus : MonoBehaviour
{
    [SerializeField]
    private StatType _changableStat;

    [SerializeField]
    private float _changeValue;

    public StatType ChangableStat => _changableStat;
    public float ChangeValue => _changeValue;

    public void Destroy()
        => Destroy(gameObject);

    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (!collider.isTrigger)
        {
            Debug.LogError($"{gameObject}'s collider must be trigger");
        }
    }
}


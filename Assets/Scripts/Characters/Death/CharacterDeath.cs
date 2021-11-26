using UnityEngine;

public class CharacterDeath : MonoBehaviour, IHitable
{
    [SerializeField]
    private GameObject _owner;

    [SerializeField]
    private Ghost _ghostPrefab;

    private bool _hited;

    public void GetHit()
    {
        if (_hited) return; // I had to write because you could get twice the damage
        // from different bomb fires. Turning off the collider would work too 
        // or come up with something more interesting
        _hited = true;
        Ghost ghostInstance = Instantiate(_ghostPrefab);
        ghostInstance.transform.position = transform.position;
        Destroy(_owner);
    }

    private void OnValidate()
    {
        if (_owner == null) _owner = gameObject;
    }
}


using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Bonus> _bonusPrefabs;

    [SerializeField] [Range(0.01f, 1f)]
    private float _bonusSpawnChance = 0.25f;

    public void TrySpawnBonus(Vector2 position)
    {
        if (Random.Range(0f, 1f) > _bonusSpawnChance) return;
        Bonus bonusPrefab = GetRandomPrefab();
        Bonus bonusInstance = Instantiate(bonusPrefab);
        bonusInstance.transform.position = position;
    }

    private Bonus GetRandomPrefab()
    {
        return _bonusPrefabs[Random.Range(0, _bonusPrefabs.Count)];
    }
}


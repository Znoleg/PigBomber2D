using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(BombSpawner))]
[RequireComponent(typeof(MovementBase), typeof(FacingSpriteChanger), typeof(CharacterStatsBase))]
public class CharacterController : MonoBehaviour
{
    private BombSpawner _bombSpawner;
    private MovementBase _movement;
    private CharacterStatsBase _characterStats;
    private FacingSpriteChanger _moveSpriteChanger;

    protected virtual void Update()
    {
        MoveDirection moveDirection = _movement.Move(_characterStats);
        _moveSpriteChanger.UpdateSprite(moveDirection);
    }

    protected virtual void Awake()
    {
        _movement = GetComponent<MovementBase>();
        _bombSpawner = GetComponent<BombSpawner>();
        _characterStats = GetComponent<CharacterStatsBase>();
        _moveSpriteChanger = GetComponent<FacingSpriteChanger>();
        _movement.OnBombSetSignal += TrySpawnBomb;
    }

    protected virtual void OnDestroy()
    {
        _movement.OnBombSetSignal -= TrySpawnBomb;
    }

    private void TrySpawnBomb()
        => _bombSpawner.TrySpawnBomb(transform.position, _characterStats);
}


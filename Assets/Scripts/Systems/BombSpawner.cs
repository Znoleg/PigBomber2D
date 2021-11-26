using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private GameGrid _gameGrid;

    [SerializeField]
    private Bomb _bombPrefab;

    public int BombsSpawned { get; private set; } = 0;

    public void TrySpawnBomb(Vector2 position, IBombStats bombStats)
    {
        if (BombsSpawned == bombStats.MaxBombCount) return; 
        Bomb bombInstance = Instantiate(_bombPrefab);
        Vector2 containingCellPosition = 
            _gameGrid.GetContainingCell(position);
        bombInstance.transform.position = containingCellPosition;

        bombInstance.StartCountdown(bombStats.BombCountdown, bombStats.BombFireRange);
        bombInstance.OnExplode += DecreaseBombCount;
        BombsSpawned++;
    }

    private void DecreaseBombCount(Bomb _)
    {
        BombsSpawned--;
    }
}


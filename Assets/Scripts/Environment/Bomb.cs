using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameGrid _gameGrid;

    [SerializeField]
    private BombFire _firePrefab;

    private uint _bombRange;

    public event Action<Bomb> OnExplode;

    public void StartCountdown(float bombCountdown, uint bombRange)
    {
        Invoke(nameof(Blow), bombCountdown);
        _bombRange = bombRange;
    }

    private void Blow()
    {
        Vector2 bombCell = _gameGrid.GetContainingCell(transform.position);

        var obstacles = new List<Obstacle>();
        var rightCells = GetCellRange(bombCell, _bombRange, 
            _gameGrid.GetRightCell, obstacles);
        var leftCells = GetCellRange(bombCell, _bombRange, 
            _gameGrid.GetLeftCell, obstacles);
        var upCells = GetCellRange(bombCell, _bombRange, 
            _gameGrid.GetUpCell, obstacles);
        var downCells = GetCellRange(bombCell, _bombRange,
            _gameGrid.GetDownCell, obstacles);
        var hitableObstacles = obstacles.Where(obst => obst.IsHitable);

        InstantiateFire(bombCell, FireType.Center, BombFire.Direction.Right);
        InstantiateFire(rightCells, BombFire.Direction.Right);
        InstantiateFire(leftCells, BombFire.Direction.Left);
        InstantiateFire(upCells, BombFire.Direction.Up);
        InstantiateFire(downCells, BombFire.Direction.Down);
        foreach (var obstacle in hitableObstacles)
        {
            obstacle.GetHitable().GetHit();
        }

        OnExplode?.Invoke(this);
        Destroy(gameObject);
    }

    private void InstantiateFire(IReadOnlyList<Vector2> cells, 
        BombFire.Direction direction)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            FireType fireType = i == cells.Count - 1 ?
                FireType.End : FireType.Straight;
            InstantiateFire(cells[i], fireType, direction);
        }
    }

    private void InstantiateFire(Vector2 cell, FireType fireType,
        BombFire.Direction direction)
    {
        BombFire fireInstance = Instantiate(_firePrefab);
        fireInstance.transform.position = cell;
        fireInstance.Activate(fireType, direction);
    }

    private List<Vector2> GetCellRange(Vector2 startingCell, uint count,
        Func<Vector2, Vector2> cellGetter, List<Obstacle> obstaclesToFill)
    {
        var cells = new List<Vector2>();
        for (int i = 1; i <= count; i++)
        {
            Vector2 nextCell = cellGetter(startingCell);
            if (_gameGrid.CellIsObstacle(nextCell, out Obstacle obstacle))
            {
                obstaclesToFill.Add(obstacle);
                break;
            }

            cells.Add(nextCell);
            startingCell = nextCell;
        }
        
        return cells;
    }

    private void Awake()
    {
        _gameGrid = GameObject.Find("Game Grid").GetComponent<GameGrid>();
    }
}

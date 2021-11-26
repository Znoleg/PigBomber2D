using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] [Min(0)]
    private int _height;

    [SerializeField] [Min(0)]
    private int _width;

    [SerializeField] [Min(0f)]
    private float _cellHeight;

    [SerializeField]
    private Vector2 _cellGap;

    [SerializeField]
    private MovementSettings _movementSetting;

    private float _additionalXToY;
    private Vector2 _cellSize;

    private readonly List<Vector2> _cellPostitions
        = new List<Vector2>();

    public List<Vector2> FreePositions // needs to be changed
    {
        get
        {
            return _cellPostitions
                .Where(cell => CellIsObstacle(cell, out Obstacle _) == false)
                .ToList();
        }
    }

    public Vector2 GetContainingCell(Vector2 point)
    {
        try
        {
            Vector2 cell = _cellPostitions.First(
                cell => new Bounds(cell, _cellSize + _cellGap).Contains(point));
            return cell;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"{GetType().Name} " +
                $"{gameObject.name} doesn't contain a cell containing " +
                $"{point} point!");
        }
    }

    public Vector2 GetRightCell(Vector2 cellPoint)
        => cellPoint + new Vector2(_cellHeight, 0f);

    public Vector2 GetLeftCell(Vector2 cellPoint)
        => cellPoint - new Vector2(_cellHeight, 0f);

    public Vector2 GetUpCell(Vector2 cellPoint)
        => cellPoint + new Vector2(_additionalXToY, _cellHeight);

    public Vector2 GetDownCell(Vector2 cellPoint)
        => cellPoint - new Vector2(_additionalXToY, _cellHeight);
    
    public bool CellIsObstacle(Vector2 cellPoint, out Obstacle obstacle)
    {
        obstacle = null;
        Collider2D overlappedCollider = Physics2D.OverlapCircle(
            cellPoint, 0.1f);
        return overlappedCollider != null &&
            overlappedCollider.transform.TryGetComponent(out obstacle);
    }

    private void CalculateCells()
    {
        _cellSize = new Vector2(_cellHeight, _cellHeight);
        Vector2 currentPosition = transform.position;
        _additionalXToY = _movementSetting
            .GetAdditionalMovement(new Vector2(0f, _cellHeight)).x;
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                float offsetFromStart = j * _cellHeight;
                float gapFromStart = j * _cellGap.x;
                Vector2 cellPosition = new Vector2(
                    currentPosition.x + offsetFromStart + gapFromStart,
                    currentPosition.y);
                _cellPostitions.Add(cellPosition);
            }

            currentPosition += new Vector2(_additionalXToY,
                _cellHeight + _cellGap.y);
        }
    }

    private void Awake()
    {
        CalculateCells();
    }

    private void OnValidate()
    {
        CalculateCells();
    }

    private void OnDrawGizmosSelected()
    {
        if (_movementSetting == null) return;
        Gizmos.color = Color.red;
        foreach (Vector2 cellPosition in _cellPostitions)
        {
            Gizmos.DrawWireCube(cellPosition, _cellSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KeyboardInput : InputReciever
{
    [SerializeField]
    private KeyCode[] _rightMoveKeys = { KeyCode.D, KeyCode.RightArrow };

    [SerializeField]
    private KeyCode[] _leftMoveKeys = { KeyCode.A, KeyCode.LeftArrow };

    [SerializeField]
    private KeyCode[] _upMoveKeys = { KeyCode.W, KeyCode.UpArrow };

    [SerializeField]
    private KeyCode[] _downMoveKeys = { KeyCode.S, KeyCode.DownArrow };

    [SerializeField]
    private KeyCode[] _placeBombKeys = { KeyCode.Space };

    private readonly Dictionary<KeyCode[], Vector2> _moveVectorDeltas
        = new Dictionary<KeyCode[], Vector2>();

    protected override void Update()
    {
        base.Update();
        if (IsBombKeyPressed())
        {
            InvokeBombKeyPressed();
        }
    }

    protected override Vector2 GetMove()
    {
        Vector2 moveVector = Vector2.zero;
        foreach (KeyCode[] moveKeys in _moveVectorDeltas.Keys)
        {
            if (IsAnyKeyPressed(moveKeys))
            {
                moveVector += _moveVectorDeltas[moveKeys];
            }
        }
        return moveVector;
    }

    private bool IsBombKeyPressed()
    {
        return IsAnyKeyPressed(_placeBombKeys);
    }

    private bool IsAnyKeyPressed(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }

    private void Awake()
    {
        _moveVectorDeltas.Add(_rightMoveKeys, new Vector2(1f, 0f));
        _moveVectorDeltas.Add(_leftMoveKeys, new Vector2(-1f, 0f));
        _moveVectorDeltas.Add(_upMoveKeys, new Vector2(0f, 1f));
        _moveVectorDeltas.Add(_downMoveKeys, new Vector2(0f, -1f));
    }
}


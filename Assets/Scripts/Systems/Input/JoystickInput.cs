using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class JoystickInput : InputReciever
{
    [SerializeField]
    private Joystick _moveJoystick;

    [SerializeField]
    private Button _setBombButton;

    protected override Vector2 GetMove()
    {
        return new Vector2(_moveJoystick.Horizontal,
            _moveJoystick.Vertical);
    }

    private void Awake()
    {
        _setBombButton.onClick.AddListener(InvokeBombKeyPressed);
    }
}


using System;
using UnityEngine;

namespace InputSystem
{
    public interface IKeyboardInput
    {
        event Action Pressed;
        event Action<Vector2> Moved;
    }
}
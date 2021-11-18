using System;
using UnityEngine;

public interface IInputManager
{
    event Action LeftClick;
    event Action<Vector2> Move;
    event Action<Vector2> Look;
    event Action<int> AlphaSelect;
    event Action Pause;
}

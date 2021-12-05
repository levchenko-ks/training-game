using System;
using UnityEngine;

public interface IScreen
{
    event Action Hided;

    void Show();
    void Hide();
}

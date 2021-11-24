using System;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    public event Action<ScoreGainers> GainScore;

    private ScoreGainers _name;

    public ScoreGainers Name { set => _name = value; }

    private void OnDisable()
    {
        GainScore?.Invoke(_name);
    }
}

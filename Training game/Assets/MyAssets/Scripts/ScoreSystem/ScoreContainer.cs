using System;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    public event Action<ScoreGainers> GainScore;

    public ScoreGainers Name;

    private void OnDestroy()
    {
        GainScore(Name);
    }
}

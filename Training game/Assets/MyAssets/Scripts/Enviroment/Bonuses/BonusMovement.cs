using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour, IBonusMovement
{
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void StartRotating()
    {
        throw new System.NotImplementedException();
    }

    public void StopRotating()
    {
        throw new System.NotImplementedException();
    }
}

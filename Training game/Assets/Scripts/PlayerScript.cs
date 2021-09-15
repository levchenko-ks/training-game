using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;

    float horizontal;
    float vertical;

    public void OnMoveInput(float _horizontal, float _vertical)
    {
        horizontal = _horizontal;
        vertical = _vertical;
        Debug.Log("Player Input: " + horizontal + " " + vertical);
    }
}

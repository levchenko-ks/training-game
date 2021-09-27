using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text Counter;

    public void SetCounter(int count)
    {
        Counter.text = count.ToString();
    }
}

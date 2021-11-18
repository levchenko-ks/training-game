using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPooler
{
    GameObject GetObject<E, T>(E item) where T : Object;
}

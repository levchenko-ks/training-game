using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private UnityEngine.Camera _cam;

    private void Awake()
    {
        _cam = UnityEngine.GameObject.Find("Main Camera").GetComponent<UnityEngine.Camera>();
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position - _cam.transform.forward);
    }
}

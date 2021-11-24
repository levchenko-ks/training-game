using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _cam;
    public Transform Cam { set => _cam = value; }

    void LateUpdate()
    {
        if(_cam == null)
        { return; }

        transform.LookAt(transform.position - _cam.transform.forward);
    }
}

using UnityEngine;

public class Billboard : MonoBehaviour
{
    private IMovable _cam;
    public IMovable Cam { set => _cam = value; }

    void LateUpdate()
    {
        if(_cam == null)
        { return; }

        transform.LookAt(transform.position - _cam.Forward);
    }
}

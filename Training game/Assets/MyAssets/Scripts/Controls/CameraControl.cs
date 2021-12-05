using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smooth = 5f;

    private IMovable _target;
    private float _height = 12f;

    void Start()
    {
        StartPositioning();
    }
    
    private void LateUpdate()
    {
        MoveCamera();
    }

    public void SetTarget(IMovable target)
    {
        _target = target;
    }

    private void StartPositioning()
    {
        var startpos = new Vector3(0f, _height, 0f);

        if (_target != null)
        {
            startpos = new Vector3(_target.Position.x, _height, _target.Position.z);
        }

        transform.position = startpos;
    }

    private void MoveCamera()
    {
        if (_target == null)
        {
            return;
        }

        var newpos = new Vector3(_target.Position.x, _height, _target.Position.z);
        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * smooth);
    }
}

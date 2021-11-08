using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smooth = 5f;

    private Transform _player;
    private float _height = 12f;


    private void Awake()
    {
        _player = ServiceLocator.GetPlayerStatic().transform;
    }

    void Start()
    {
        StartPositioning();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void StartPositioning()
    {
        var startpos = new Vector3(transform.position.x, _height, transform.position.z);

        if (_player != null)
        {
            startpos = new Vector3(_player.position.x, _height, _player.position.z);
        }

        transform.position = startpos;
    }

    private void MoveCamera()
    {
        if (_player == null)
        {
            return;
        }

        var newpos = new Vector3(_player.position.x, _height, _player.position.z);
        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * smooth);
    }
}

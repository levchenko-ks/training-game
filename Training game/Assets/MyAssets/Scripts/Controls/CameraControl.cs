using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smooth = 5f;

    private Camera _cam;
    private InputControls _gameplayControls;
    private Transform _player;
    private Transform _target;
    private float _horizontal;
    private float _vertical;
    private float _height = 12f;

    public Transform Player { get => _player; set => _player = value; }
    public Transform Target { get => _target; set => _target = value; }
    public InputControls GameplayControls
    {
        get => _gameplayControls;
        set
        {
            _gameplayControls = value;
            _gameplayControls.Look += OnLook;
        }
    }

    void Start()
    {
        _cam = Camera.main;

        StartPositioning();
    }
    void Update()
    {
        MoveTarget();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void OnLook(Vector2 obj)
    {
        _horizontal = Mathf.Clamp(obj.x, 0f, Screen.width);
        _vertical = Mathf.Clamp(obj.y, 0f, Screen.height);
    }

    private void StartPositioning()
    {
        var startpos = new Vector3(transform.position.x, _height, transform.position.z);

        if (_player != null)
        {
            startpos = new Vector3(_player.transform.position.x, _height, _player.transform.position.z);
        }

        transform.position = startpos;

    }

    private void MoveCamera()
    {
        if (_player == null)
        {
            return;
        }

        var newpos = new Vector3(_player.transform.position.x, _height, _player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * smooth);
    }

    private void MoveTarget()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 hitpos;
        RaycastHit hit;
        Ray mouseRay = _cam.ScreenPointToRay(new Vector3(_horizontal, _vertical, _height));

        if (Physics.Raycast(mouseRay, out hit))
        {
            hitpos = new Vector3(hit.point.x, _target.position.y, hit.point.z);
            _target.position = hitpos;
        }
    }
}

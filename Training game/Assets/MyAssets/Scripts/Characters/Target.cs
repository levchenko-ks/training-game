using UnityEngine;

public class Target : MonoBehaviour
{
    private IInputManager _inputManager;
    private Camera _mainCamera;
    private Transform _cameraPosition;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {        
        _inputManager = ServiceLocator.GetInputManager();        
        _cameraPosition = ServiceLocator.GetCamera().transform;        
        _inputManager.Look += OnLook;
        _mainCamera = Camera.main;        
    }

    private void Update()
    {
        Moving();
    }

    private void OnDestroy()
    {
        _inputManager.Look -= OnLook;
    }

    private void OnLook(Vector2 obj)
    {
        _horizontal = Mathf.Clamp(obj.x, 0f, Screen.width);
        _vertical = Mathf.Clamp(obj.y, 0f, Screen.height);
    }

    private void Moving()
    {
        if (_mainCamera == null)
        {
            return;
        }

        Vector3 hitpos;
        RaycastHit hit;
        Ray mouseRay = _mainCamera.ScreenPointToRay(new Vector3(_horizontal, _vertical, _cameraPosition.transform.position.y));

        if (Physics.Raycast(mouseRay, out hit))
        {
            hitpos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.position = hitpos;
        }
    }


}

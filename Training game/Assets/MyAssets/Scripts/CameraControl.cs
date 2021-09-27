using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    public Transform Target;
    public float smooth = 5f;

    private Camera _cam;
    private float _horizontal;
    private float _vertical;
    private float _height = 12f;

    void Start()
    {
        var startpos = new Vector3(Player.transform.position.x, _height, Player.transform.position.z);
        transform.position = startpos;

        _cam = Camera.main;
    }

    void Update()
    {
        Vector3 newpos;
        Vector3 hitpos;
        RaycastHit hit;
        Ray mouseRay = _cam.ScreenPointToRay(new Vector3(_horizontal, _vertical, _height));

        if (Physics.Raycast(mouseRay, out hit))
        {
            hitpos = new Vector3(hit.point.x, Target.position.y, hit.point.z);
            Target.position = hitpos;
        }


        newpos = new Vector3(Player.transform.position.x, _height, Player.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * smooth);
    }

    public void OnLookInput(float horizontal, float vertical)
    {
        _horizontal = Mathf.Clamp(horizontal, 0f, Screen.width);
        _vertical = Mathf.Clamp(vertical, 0f, Screen.height);
    }
}

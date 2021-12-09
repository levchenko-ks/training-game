using UnityEngine;

public interface IMovable
{
    Vector3 Position { get; }
    Vector3 Forward { get; }
    Quaternion Rotation { get; }

    void SetPosition(Vector3 pos);
}
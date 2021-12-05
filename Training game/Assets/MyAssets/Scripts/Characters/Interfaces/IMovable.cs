using UnityEngine;

public interface IMovable
{
    Vector3 Position { get; }
    Quaternion Rotation { get; }
}
using UnityEngine;

public abstract class Path : MonoBehaviour
{
    public abstract Vector3 GetPoint(float interpolateAmount);
    public abstract Vector3 GetTangent(float t);

    public abstract Vector3 GetNormal2D(float t);

    public abstract Vector3 GetNormal3D(float t, Vector3 up);

    public abstract Quaternion GetOrientation2D(float t);

    public abstract Quaternion GetOrientation3D(float t, Vector3 up);
}
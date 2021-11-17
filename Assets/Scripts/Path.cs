using UnityEngine;

public abstract class Path : MonoBehaviour
{
    public abstract Vector3 GetPoint(float interpolateAmount, Space space = Space.World);
}
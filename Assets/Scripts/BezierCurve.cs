using UnityEngine;

public class BezierCurve : Path
{
    public Vector3 p0;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;

    public void Reset()
    {
        p0 = new Vector3(-1f, 0f, 0f);
        p1 = new Vector3(0f, 0f, 1f);
        p2 = new Vector3(1f, 0f, 1f);
        p3 = new Vector3(3f, 0f, 0f);
    }

    public Vector3 QuadraticLerp(Vector3 p0, Vector3 p1, Vector3 p2, float amount)
    {
        var h1 = Vector3.Lerp(p0, p1, amount);
        var h2 = Vector3.Lerp(p1, p2, amount);
        return Vector3.Lerp(h1, h2, amount);
    }

    public Vector3 CubicLerp(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float amount)
    {
        var h1 = QuadraticLerp(p0, p1, p2, amount);
        var h2 = QuadraticLerp(p1, p2, p3, amount);

        return Vector3.Lerp(h1, h2, amount);
    }

    public override Vector3 GetPoint(float interpolateAmount, Space space = Space.World)
    {
        var ret = CubicLerp(p0, p1, p2, p3, interpolateAmount);
        if (space == Space.World)
        {
            ret = transform.TransformPoint(ret);
        }

        return ret;
    }
}
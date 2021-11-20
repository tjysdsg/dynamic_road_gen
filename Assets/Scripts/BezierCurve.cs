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

    /*
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
    */

    public override Vector3 GetPoint(float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;
        var ret = p0 * (omt2 * omt) +
                  p1 * (3f * omt2 * t) +
                  p2 * (3f * omt * t2) +
                  p3 * (t2 * t);
        // var ret = CubicLerp(p0, p1, p2, p3, t);
        return ret;
    }

    public override Vector3 GetTangent(float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;
        Vector3 tangent =
            p0 * (-omt2) +
            p1 * (3 * omt2 - 2 * omt) +
            p2 * (-3 * t2 + 2 * t) +
            p3 * (t2);
        return tangent.normalized;
    }

    public override Vector3 GetNormal2D(float t)
    {
        Vector3 tng = GetTangent(t);
        return new Vector3(-tng.y, tng.x, 0f);
    }

    public override Vector3 GetNormal3D(float t, Vector3 up)
    {
        Vector3 tng = GetTangent(t);
        Vector3 binormal = Vector3.Cross(up, tng).normalized;
        return Vector3.Cross(tng, binormal);
    }

    public override Quaternion GetOrientation2D(float t)
    {
        Vector3 tng = GetTangent(t);
        Vector3 nrm = GetNormal2D(t);
        return Quaternion.LookRotation(tng, nrm);
    }

    public override Quaternion GetOrientation3D(float t, Vector3 up)
    {
        Vector3 tng = GetTangent(t);
        Vector3 nrm = GetNormal3D(t, up);
        return Quaternion.LookRotation(tng, nrm);
    }
}
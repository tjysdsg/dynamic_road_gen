using UnityEngine;

public class MeshVert : Object
{
    public Vector3 point;
    public Vector3 normal;
    public float uCoord;

    public MeshVert(Vector3 point, Vector3 normal, float uCoord)
    {
        // TODO: normalize normal
        this.point = point;
        this.normal = normal;
        this.uCoord = uCoord;
    }
}
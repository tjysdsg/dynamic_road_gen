using System.Collections.Generic;
using UnityEngine;

public class RoadMeshGen : MonoBehaviour
{
    private Path path;
    private int edgeLoopPerTexture = 50;

    private void Start()
    {
        path = GetComponent<Path>();
        ExtrudeShape shape = ExtrudeShape.SimpleRoad();
        Extrude(shape, 100);
    }

    public void Extrude(ExtrudeShape shape, int smoothness)
    {
        var orientedPoints = new List<OrientedPoint>();
        float step = 1.0f / smoothness;
        for (float t = 0; t <= 1.0f; t += step)
        {
            orientedPoints.Add(new OrientedPoint(
                    path.GetPoint(t),
                    path.GetOrientation3D(t, Vector3.up)
                )
            );
        }

        Extrude(shape, orientedPoints.ToArray());
    }

    public void Extrude(ExtrudeShape shape, OrientedPoint[] orientedPoints)
    {
        int vertsInShape = shape.vert2Ds.Length;
        int segments = orientedPoints.Length - 1;
        int edgeLoops = orientedPoints.Length;
        int vertCount = vertsInShape * edgeLoops;
        int triCount = shape.lines.Length * segments;
        int triIndexCount = triCount * 3;

        int[] triangleIndices = new int[triIndexCount];
        Vector3[] vertices = new Vector3[vertCount];
        Vector3[] normals = new Vector3[vertCount];
        Vector2[] uvs = new Vector2[vertCount];

        MeshFilter mf = GetComponent<MeshFilter>();
        mf.sharedMesh = new Mesh();
        Mesh mesh = mf.sharedMesh;
        mesh.Clear();

        for (int i = 0; i < edgeLoops; i++)
        {
            int offset = i * vertsInShape;
            for (int j = 0; j < vertsInShape; j++)
            {
                int id = offset + j;
                vertices[id] = orientedPoints[i].LocalToWorld(shape.vert2Ds[j].point);
                normals[id] = orientedPoints[i].LocalToWorldDirection(shape.vert2Ds[j].normal);
                uvs[id] = new Vector2(shape.vert2Ds[j].uCoord, i / (float)edgeLoopPerTexture);
            }
        }

        int ti = 0;
        for (int i = 0; i < segments; i++)
        {
            int offset = i * vertsInShape;
            for (int l = 0; l < shape.lines.Length; l += 2)
            {
                int a = offset + shape.lines[l] + vertsInShape;
                int b = offset + shape.lines[l];
                int c = offset + shape.lines[l + 1];
                int d = offset + shape.lines[l + 1] + vertsInShape;
                triangleIndices[ti] = a;
                ti++;
                triangleIndices[ti] = b;
                ti++;
                triangleIndices[ti] = c;
                ti++;
                triangleIndices[ti] = c;
                ti++;
                triangleIndices[ti] = d;
                ti++;
                triangleIndices[ti] = a;
                ti++;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangleIndices;
        mesh.normals = normals;
        mesh.uv = uvs;
    }
}
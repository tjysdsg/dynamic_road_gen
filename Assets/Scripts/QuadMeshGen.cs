using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMeshGen : MonoBehaviour
{
    Vector3[] vertices =
    {
        new Vector3(1, 0, 1),
        new Vector3(-1, 0, 1),
        new Vector3(1, 0, -1),
        new Vector3(-1, 0, -1)
    };

    Vector3[] normals =
    {
        new Vector3(0, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 1, 0)
    };

    Vector2[] uvs =
    {
        new Vector2(1, 1),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(0, 0)
    };

    int[] triangles =
    {
        0, 2, 3,
        3, 1, 0
    };

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf.sharedMesh == null)
            mf.sharedMesh = new Mesh();
        Mesh mesh = mf.sharedMesh;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }

    void Update()
    {
    }
}
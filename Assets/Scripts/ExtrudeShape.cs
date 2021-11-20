using UnityEngine;

public class ExtrudeShape
{
    public MeshVert[] vert2Ds;
    public int[] lines;

    /**
     * Shape of a road like this:
     * 
     * ___         ___
     * |  \_______/  |
     * |_____________|
     * 
     */
    public static ExtrudeShape SimpleRoad()
    {
        return new ExtrudeShape
        {
            lines = new[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            },
            vert2Ds = new[]
            {
                // |
                // |
                new MeshVert(new Vector3(-0.5f, 0.3f, 0), new Vector3(-1, 0, 0), 0.2f),
                new MeshVert(new Vector3(-0.5f, 0, 0), new Vector3(-1, 0, 0), 0),

                // ___
                new MeshVert(new Vector3(-0.4f, 0.3f, 0), new Vector3(0, 1, 0), 0.3f),
                new MeshVert(new Vector3(-0.5f, 0.3f, 0), new Vector3(0, 1, 0), 0.2f),

                // \
                new MeshVert(new Vector3(-0.3f, 0.2f, 0), new Vector3(1, 1, 0), 0.4f),
                new MeshVert(new Vector3(-0.4f, 0.3f, 0), new Vector3(1, 1, 0), 0.3f),

                // ___
                new MeshVert(new Vector3(0.3f, 0.2f, 0), new Vector3(0, 1, 0), 0.6f),
                new MeshVert(new Vector3(-0.3f, 0.2f, 0), new Vector3(0, 1, 0), 0.4f),

                // /
                new MeshVert(new Vector3(0.4f, 0.3f, 0), new Vector3(-1, 1, 0), 0.7f),
                new MeshVert(new Vector3(0.3f, 0.2f, 0), new Vector3(-1, 1, 0), 0.6f),

                // ___
                new MeshVert(new Vector3(0.5f, 0.3f, 0), new Vector3(0, 1, 0), 0.8f),
                new MeshVert(new Vector3(0.4f, 0.3f, 0), new Vector3(0, 1, 0), 0.7f),

                // |
                // |
                new MeshVert(new Vector3(0.5f, 0, 0), new Vector3(1, 0, 0), 0.9f),
                new MeshVert(new Vector3(0.5f, 0.3f, 0), new Vector3(1, 0, 0), 0.8f),

                // _____________
                new MeshVert(new Vector3(-0.5f, 0, 0), new Vector3(0, -1, 0), 1),
                new MeshVert(new Vector3(0.5f, 0, 0), new Vector3(0, -1, 0), 0.9f),
            }
        };
    }
}
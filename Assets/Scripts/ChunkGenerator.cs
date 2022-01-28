using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    private void Start()
    {
        int vertIndex = 0;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                int triIndex = VoxelData.tris[i, j];
                vertices.Add(VoxelData.verts[triIndex]);
                triangles.Add(vertIndex);

                uvs.Add(VoxelData.uvs[i]);

                vertIndex++;
            }
        }

        Mesh mesh = new Mesh
        {
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray(),
            uv = uvs.ToArray()
        };

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}

using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public MeshFilter meshFilter;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    void Start()
    {
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        for (int x = 0; x < xSize; x++)
        {
            triangles = new int[6];
            triangles[0] = vert + 0;
            triangles[1] = vert + xSize + 1;
            triangles[2] = vert + 1;

            triangles[3] = vert + 1;
            triangles[4] = vert + xSize + 1;
            triangles[5] = vert + xSize + 2;

            vert++;
            tris += 6;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return; // prevent while in edit mode

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}

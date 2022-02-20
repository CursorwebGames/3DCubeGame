using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    private Mesh mesh;

    private int vertexIndex = 0;
    private readonly List<Vector3> vertices = new List<Vector3>();
    private readonly List<int> triangles = new List<int>();
    private readonly List<Vector2> uvs = new List<Vector2>();

    public WorldManager world;

    private BlockType[,,] voxelMap = new BlockType[VoxelData.chunkWidth, VoxelData.chunkHeight, VoxelData.chunkWidth];

    private void Start()
    {
        world = GameObject.Find("GameManager").GetComponent<WorldManager>();

        mesh = new Mesh();
        meshFilter.mesh = mesh;

        // add the internals
        PopulateVoxelMap();
        // render internals
        CreateMeshData();
        // render to unity
        UpdateMesh();
    }

    private void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelData.chunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.chunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                {
                    voxelMap[x, y, z] = BlockType.Grass;
                }
            }
        }

    }

    private void CreateMeshData()
    {
        for (int y = 0; y < VoxelData.chunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.chunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                {
                    AddVoxel(new Vector3(x, y, z));
                }
            }
        }

    }

    private bool VoxelAir(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);

        if (x < 0 || x > VoxelData.chunkWidth - 1 || y < 0 || y > VoxelData.chunkHeight - 1 || z < 0 || z > VoxelData.chunkWidth - 1)
            return true;

        return world.blockData[voxelMap[x, y, z]].isSolid;
    }

    private void AddVoxel(Vector3 pos)
    {
        for (int p = 0; p < 6; p++)
        {
            // only add face if its air
            if (VoxelAir(pos + VoxelData.faceChecks[p]))
            {
                BlockType blockType = voxelMap[(int)pos.x, (int)pos.y, (int)pos.z];

                vertices.Add(pos + VoxelData.verts[VoxelData.tris[p, 0]]);
                vertices.Add(pos + VoxelData.verts[VoxelData.tris[p, 1]]);
                vertices.Add(pos + VoxelData.verts[VoxelData.tris[p, 2]]);
                vertices.Add(pos + VoxelData.verts[VoxelData.tris[p, 3]]);

                AddTexture(world.blockData[blockType].textureIds[p]);

                triangles.Add(vertexIndex);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 2);
                triangles.Add(vertexIndex + 1);
                triangles.Add(vertexIndex + 3);
                vertexIndex += 4;
            }
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        // rendering
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.Optimize();
        mesh.RecalculateNormals();

        // collision
        mesh.RecalculateBounds();
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    private void AddTexture(int textureID, bool random = true)
    {
        int orientation = random ? Random.Range(0, 4) : 1;

        float y = textureID / VoxelData.blockWidths;
        float x = textureID - (y * VoxelData.blockWidths);

        x *= VoxelData.blockRatios;
        y *= VoxelData.blockRatios;
        
        y = 1f - y - VoxelData.blockRatios; // start at 0

        switch (orientation)
        {
            case 0:
                // down
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y));
                uvs.Add(new Vector2(x, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x, y));
                break;
            case 1:
                // normal
                uvs.Add(new Vector2(x, y));
                uvs.Add(new Vector2(x, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y + VoxelData.blockRatios));
                break;
            case 2:
                // right
                uvs.Add(new Vector2(x, y));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y));
                uvs.Add(new Vector2(x, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y + VoxelData.blockRatios));
                break;
            case 3:
                // left
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x, y + VoxelData.blockRatios));
                uvs.Add(new Vector2(x + VoxelData.blockRatios, y));
                uvs.Add(new Vector2(x, y));
                break;
        }
    }
}
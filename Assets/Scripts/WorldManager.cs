using System;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class WorldManager : MonoBehaviour
{
    private int seedNum;
    private FastNoiseLite noise;

    public Material material;
    public Dictionary<BlockType, BlockInfo> blockData = new Dictionary<BlockType, BlockInfo>() {
        { BlockType.Grass, new BlockInfo("Grass Block", new int[] { 1, 1, 2, 0, 1, 1 }) },
        { BlockType.Dirt, new BlockInfo("Dirt", 0) },
        { BlockType.Stone, new BlockInfo("Stone", 3) },
        { BlockType.Bedrock, new BlockInfo("Bedrock", 4) }
    };

    private void Start()
    {
        seedNum = Random.Range(0, 10_000);
        noise = new FastNoiseLite(seedNum);
        for (int x = -4; x < 4; x++)
        {
            for (int z = -4; z < 4; z++)
            {
                ChunkGenerator newChunk = new ChunkGenerator(this, noise, new ChunkPos(x, z));
            }
        }
    }
}

[Serializable]
public class BlockInfo
{
    public string name;
    public bool isSolid;

    // back front top bottom left right
    public int[] textureIds = new int[6];

    /// <summary>back front top bottom left right</summary>
    public BlockInfo(string name, int[] textureIds, bool solid = true)
    {
        this.name = name;
        this.isSolid = solid;
        this.textureIds = textureIds;
    }

    public BlockInfo(string name, int textureId, bool solid = true)
    {
        this.name = name;
        this.isSolid = solid;

        int[] textureIds = new int[6];
        for (int i = 0; i < 6; i++)
        {
            textureIds[i] = textureId;
        }

        this.textureIds = textureIds;
    }
}

[Serializable]
/// <summary>Relative chunk coords</summary>
public struct ChunkPos
{
    public int x, z;

    public ChunkPos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}

[Serializable]
public enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone,
    Bedrock
}

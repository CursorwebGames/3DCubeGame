using System;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class WorldManager : MonoBehaviour
{
    private int seedNum;
    private TerrainGenerator generator;

    public Material material;


    // block infos
    public Dictionary<BlockType, BlockInfo> blockData = new Dictionary<BlockType, BlockInfo>() {
        { BlockType.Grass, new BlockInfo("Grass Block", new int[] { 1, 1, 2, 0, 1, 1 }) },
        { BlockType.Dirt, new BlockInfo("Dirt", 0) },
        { BlockType.Stone, new BlockInfo("Stone", 3) },
        { BlockType.Bedrock, new BlockInfo("Bedrock", 4) },
        { BlockType.Glass, new BlockInfo("Glass", 5) }
    };

    public bool isSolid(BlockType type) {
        if (type == BlockType.Air) return false;
        return blockData[type].isSolid;
    }


    // world container
    ChunkGenerator[,] worldMap = new ChunkGenerator[8, 8];

    public BlockType GetBlock(int x, int y, int z) {
        return generator.GetBlock(x, y, z);
    }


    // chunk gen
    private void Start()
    {
        seedNum = Random.Range(0, 10_000);
        generator = new TerrainGenerator(seedNum);

        for (int x = 0; x < 8; x++)
        {
            for (int z = 0; z < 8; z++)
            {
                NewChunk(x, z);
            }
        }
    }

    private void NewChunk(int x, int z)
    {
        worldMap[x, z] = new ChunkGenerator(this, new ChunkPos(x, z));
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

    public int AbsX(int x) {
        return this.x * 16 + x;
    }

    public int AbsZ(int z) {
        return this.z * 16 + z;
    }
}

[Serializable]
public enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone,
    Bedrock,
    Glass
}

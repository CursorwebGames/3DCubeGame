using System;
using System.Collections.Generic;

using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Material material;
    public Dictionary<BlockType, BlockInfo> blockData = new Dictionary<BlockType, BlockInfo>() {
        { BlockType.Grass, new BlockInfo("Grass Block", new int[] { 1, 1, 2, 0, 1, 1 }) },
        { BlockType.Dirt, new BlockInfo("Dirt", 0) },
        { BlockType.Stone, new BlockInfo("Stone", 3) },
        { BlockType.Bedrock, new BlockInfo("Bedrock", 4) }
    };
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
public enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone,
    Bedrock
}

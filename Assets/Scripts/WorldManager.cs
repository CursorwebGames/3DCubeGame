using System;
using System.Collections.Generic;

using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Material material;
    public Dictionary<BlockType, BlockInfo> blockData = new Dictionary<BlockType, BlockInfo>() {
        { BlockType.Grass, new BlockInfo("Grass Block", false, new int[] { 1, 1, 2, 0, 1, 1 }) },
        { BlockType.Dirt, new BlockInfo("Dirt", false, 0) },
        { BlockType.Stone, new BlockInfo("Stone", false, 3) }
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
    public BlockInfo(string name, bool isSolid, int[] textureIds)
    {
        this.name = name;
        this.isSolid = isSolid;
        this.textureIds = textureIds;
    }

    public BlockInfo(string name, bool isSolid, int textureId)
    {
        this.name = name;
        this.isSolid = isSolid;

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
    Stone
}

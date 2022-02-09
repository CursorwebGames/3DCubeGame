using System;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public Material material;
    public Block[] blocks;
}

[Serializable]
public class Block
{
    public string name;
    public bool isSolid;
}

enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone
}

using UnityEngine;

public class TerrainGenerator {
    private int seedNum;
    private FastNoiseLite noise;

    public TerrainGenerator(int seed) {
        seedNum = seed;
        noise = new FastNoiseLite(seedNum);
    }

    public BlockType GetBlock(int x, int y, int z)
    {
        if (y == 0)
        {
            return BlockType.Bedrock;
        }
        else
        {
            int height = TerrainHeight(x, z);
            if (y > height)
            {
                return BlockType.Air;
            }
            else if (y == height)
            {
                return BlockType.Grass;
            }
            else if (y < height)
            {
                return BlockType.Stone;
            }

            return BlockType.Air;
        }
    }
    
    private int TerrainHeight(int x, int z)
    {
        float noise1 = (noise.GetNoise(x * .3f, z * .3f) + 1) * 5;
        float noise2 = (noise.GetNoise(x * 3f, z * 3f)) * 5 * (noise.GetNoise(x * .3f, z * .3f) + 1);

        int height = Mathf.Clamp(Mathf.RoundToInt(noise1 + noise2), 1, VoxelData.chunkHeight);
        return height;
    }
}
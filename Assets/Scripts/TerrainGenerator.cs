using UnityEngine;

public class TerrainGenerator
{
    private int seedNum;
    private FastNoiseLite noise;

    public TerrainGenerator(int seed)
    {
        seedNum = seed;
        noise = new FastNoiseLite(seedNum);

        Random.InitState(seed);
    }

    public BlockType GetBlock(int x, int y, int z)
    {
        if (y == 0)
        {
            return BlockType.Bedrock;
        }
        else
        {
            int height = Mathf.FloorToInt(Mathf.Abs(x * (Mathf.Sin(x + z + seedNum)) + z * Mathf.Cos(x - z + seedNum)) % 10 + 3);
            float percent = Mathf.Clamp(Mathf.Sin(x + z), 0, 1);
            
            if (y == height)
            {
                return BlockType.Grass;
            }
            else if (y < height * percent)
            {
                return BlockType.Stone;
            }
            else if (y < height)
            {
                return BlockType.Dirt;
            }

            return BlockType.Air;

            /*
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
            */
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
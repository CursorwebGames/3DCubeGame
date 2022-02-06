using UnityEngine;
using UnityEngine.UI;

public class TerrainGeneration : MonoBehaviour
{
    public Material[] materials;
    public Text seed;

    private void Start()
    {
        int seedNum = Random.Range(0, 10_000);
        seed.text = seedNum.ToString();

        FastNoiseLite noise = new FastNoiseLite(seedNum);
        noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);

        for (int x = 0; x < 100; x++)
        {
            for (int z = 0; z < 100; z++)
            {

                float noise1 = (noise.GetNoise(x * .3f, z * .3f) + 1) * 5;
                float noise2 = (noise.GetNoise(x * 3f, z * 3f)) * 5 * (noise.GetNoise(x * .3f, z * .3f) + 1);

                int height = Mathf.Clamp(Mathf.RoundToInt(noise1 + noise2), 1, 64);

                GameObject cube;

                for (int y = Mathf.Clamp(height - 1, 0, height); y < height; y++)
                {
                    cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x, y, z);
                    cube.GetComponent<MeshRenderer>().material = materials[materials.Length - 1];
                    cube.layer = 6;
                }

                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, height, z);
                cube.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length - 1)];
                cube.layer = 6;
            }
        }
    }
}

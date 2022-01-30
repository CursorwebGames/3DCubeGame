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
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                float noise1 = (noise.GetNoise(x * .3f, z * .3f) + 1) * 5;
                float noise2 = (noise.GetNoise(x * 3f, z * 3f)) * 5 * (noise.GetNoise(x * .3f, z * .3f) + 1);

                float y = Mathf.Clamp(Mathf.Round(noise1 + noise2), 1, 64);
                cube.transform.position = new Vector3(x, y, z);
                cube.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
                cube.layer = 6;
            }
        }
    }
}

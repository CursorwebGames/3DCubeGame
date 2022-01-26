using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public Material[] materials;

    private void Start()
    {
        SimplexNoiseGenerator noise = new SimplexNoiseGenerator();

        for (int x = 0; x < 100; x++)
        {
            for (int z = 0; z < 100; z++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                float y = Mathf.Round((noise.coherentNoise(x, 0, z)) * 50);
                cube.transform.position = new Vector3(x, y, z);
                cube.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
                cube.layer = 6;
            }
        }
    }
}

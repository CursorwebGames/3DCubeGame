using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public Material[] materials;

    private void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, 0f, z);
                cube.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
            }
        }
    }
}

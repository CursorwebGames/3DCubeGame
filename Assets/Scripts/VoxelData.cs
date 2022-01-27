using UnityEngine;

public static class VoxelData
{
	public static readonly Vector3[] verts = new Vector3[] {
		new Vector3(0, 0, 0),
		new Vector3(1, 0, 0),
		new Vector3(1, 1, 0),
		new Vector3(0, 1, 0),
		new Vector3(0, 0, 1),
		new Vector3(1, 0, 1),
		new Vector3(1, 1, 1),
		new Vector3(0, 1, 1),
	};

	public static readonly int[,] tris = new int[,] {
		{0, 3, 1, 1, 3, 2}, // Back Face
		{5, 6, 4, 4, 6, 7}, // Front Face
		{3, 7, 2, 2, 7, 6}, // Top Face
		{1, 5, 0, 0, 5, 4}, // Bottom Face
		{4, 7, 0, 0, 7, 3}, // Left Face
		{1, 2, 5, 5, 2, 6} // Right Face
	};

	// directions to look for
	public static readonly Vector2[] uvs = new Vector2[] {
		new Vector2(0, 0),
		new Vector2(0, 1),
		new Vector2(1, 0),
		new Vector2(1, 0),
		new Vector2(0, 1),
		new Vector2(1, 1)
	};
}
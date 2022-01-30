using UnityEngine;

public static class VoxelData
{
	public static readonly int chunkWidth = 16;
	public static readonly int chunkHeight = 64;

	public static readonly Vector3[] verts = new Vector3[8] {
		new Vector3(0, 0, 0),
		new Vector3(1, 0, 0),
		new Vector3(1, 1, 0),
		new Vector3(0, 1, 0),
		new Vector3(0, 0, 1),
		new Vector3(1, 0, 1),
		new Vector3(1, 1, 1),
		new Vector3(0, 1, 1),
	};

	public static readonly Vector3[] faceChecks = new Vector3[6] {
		new Vector3(0, 0, -1),
		new Vector3(0, 0, 1),
		new Vector3(0, 1, 0),
		new Vector3(0, -1, 0),
		new Vector3(-1, 0, 0),
		new Vector3(1, 0, 0),
	};

	public static readonly int[,] tris = new int[6, 4] {
		{ 0, 3, 1, 2 }, // Back Face
		{ 5, 6, 4, 7 }, // Front Face
		{ 3, 7, 2, 6 }, // Top Face
		{ 1, 5, 0, 4 }, // Bottom Face
		{ 4, 7, 0, 3 }, // Left Face
		{ 1, 2, 5, 6 }, // Right Face
	};

	public static readonly Vector2[] uvs = new Vector2[4] {
		new Vector2 (0, 0),
		new Vector2 (0, 1),
		new Vector2 (1, 0),
		new Vector2 (1, 1)
	};
}
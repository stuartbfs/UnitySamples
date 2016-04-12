using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour 
{
	private const int Space = 0;
	private const int Wall = 1;

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed;

	[Range(0, 100)]
	public int randomFillPercent;

	private int[,] map;

	void Start() 
	{
		GenerateMap ();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			GenerateMap ();
		}
	}

	void GenerateMap() 
	{
		map = new int[width, height];
		RandomFillMap ();
		for (var i = 0; i < 5; i++) {
			SmoothMap ();
		}
	}

	void RandomFillMap() 
	{
		System.Random pseudoRandom;

		if (useRandomSeed) 
		{
			pseudoRandom = new System.Random (Guid.NewGuid().GetHashCode());
		}
		else 
		{
			pseudoRandom = new System.Random (seed.GetHashCode ());
		}

		foreach (MapPoint mapPoint in Iterate(width, height)) 
		{
			if (mapPoint.X == 0 || mapPoint.X == width - 1 || mapPoint.Y == 0 || mapPoint.Y == height -1)
			{
				map[mapPoint.X,mapPoint.Y] = Wall;
			}
			else
			{
				map [mapPoint.X, mapPoint.Y] = (pseudoRandom.Next (0, 100) < randomFillPercent) ? Wall : Space;
			}
		}
	}

	void SmoothMap()
	{
		foreach (MapPoint mapPoint in Iterate(width, height)) 
		{
			int neighbourWallTiles = GetSurroundingWallCount (mapPoint.X, mapPoint.Y);

			if (neighbourWallTiles > 4) 
			{
				map [mapPoint.X, mapPoint.Y] = Wall;
			}
			else if (neighbourWallTiles < 4)
			{
				map [mapPoint.X, mapPoint.Y] = Space;
			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY)
	{
		int wallCount = 0;
		foreach (var p in Iterate(gridX-1, gridX+1, gridY-1, gridY+1)) 
		{
			if (p.X >= 0 && p.X < width && p.Y >= 0 && p.Y < height) 
			{
				if (p.X != gridX || p.Y != gridY) 
				{
					wallCount += map [p.X, p.Y];
				}
			} 
			else 
			{
				wallCount++;
			}
		}
		return wallCount;
	}

	void OnDrawGizmos()
	{
		if (map == null)
			return;

		foreach (var p in Iterate(width, height)) 
		{
			Gizmos.color = (map [p.X, p.Y] == Wall) ? Color.black : Color.white;
			Vector3 pos = new Vector3 (-width / 2 + p.X + 0.5f, 0, -height / 2 + p.Y + 0.5f);
			Gizmos.DrawCube (pos, Vector3.one);
		}
	}

	public static IEnumerable<MapPoint> Iterate(int width, int height)
	{
		for (int x = 0; x < width; x++) 
		{
			for (int y = 0; y < height; y++) 
			{
				yield return new MapPoint { X = x, Y = y };
			}
		}
	}

	public static IEnumerable<MapPoint> Iterate(int startX, int endX, int startY, int endY)
	{
		for (int x = startX; x <= endX; x++) 
		{
			for (int y = startY; y <= endY; y++) 
			{
				yield return new MapPoint { X = x, Y = y };
			}
		}
	}
}

public struct MapPoint
{
	public int X { get; set; }

	public int Y { get; set; }
}

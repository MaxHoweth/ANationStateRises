using UnityEngine;
using System.Collections;

public class mapGenerator : MonoBehaviour {
	public int mapWidth;
	public int mapHeight;
	public float noiseScale;
	public bool autoUpdate;

	public int octaves;
	public float persistance;
	public float lacunarity;

	public void generateMap() {
		float[,] noiseMap = Noise.generateNoiseMap(mapWidth,mapHeight,noiseScale,octaves,persistance,lacunarity);

		mapDisplay display = FindObjectOfType<mapDisplay>();
		display.drawNoiseMap(noiseMap);
	}

}

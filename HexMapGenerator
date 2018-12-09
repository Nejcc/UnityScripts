using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Collections

public class HexMapGenerator : MonoSingleton<HexMapGenerator> {

	[Header("Map size:")]
	[SerializeField] public int mapWidth = 25;
	[SerializeField] public int mapHeight = 12;

	[Header("Tile offset:")]
	[SerializeField] private float tileXoffset = 1.8f; //gap
	[SerializeField] private float tileZoffset = 1.565f; //gap

	[Header("Settings obj:")]
	[SerializeField] private GameObject hexTilePrefab;
	[SerializeField] private Transform tileHolder;

	void Start () {
		CreateHexTileMap();
	}

	void CreateHexTileMap () {

		//Generating tiles to start with 0,0 on center
		float mapXmin = -mapWidth / 2;
		float mapXmax =  mapWidth / 2;
		
		float mapZmin = -mapHeight / 2;
		float mapZmax =  mapHeight / 2;

		//Generate map
		for(float x = mapXmin; x < mapXmax; x++)
		{
			for(float z = mapZmin; z <= mapZmax; z++)
			{
				//Spot hex in the game
				GameObject TileGameObj = Instantiate(hexTilePrefab);

				//Pass position of the action tile
				Vector3 pos;

				//positions of the tiles
				if(z % 2 == 0)
				{
					// TileGameObj.transform.position = new Vector3(x * tileXoffset,0,z*tileZoffset);
					pos = new Vector3(x * tileXoffset,0,z*tileZoffset);
				}
				else
				{
					// TileGameObj.transform.position = new Vector3(x*tileXoffset + tileXoffset / 2, 0,z*tileZoffset);
					pos = new Vector3(x*tileXoffset + tileXoffset / 2, 0,z*tileZoffset);
				}

				//Set naming for the map
				StartCoroutine(SetTileInfo(TileGameObj, x, z, pos));
			}
		}
	}

	IEnumerator SetTileInfo(GameObject TileGameObj, float x, float z, Vector3 pos){

		//delay for check the OnTriggerExit 
		yield return new WaitForSeconds(0.00001f);

		//transform the tile
		TileGameObj.transform.parent = tileHolder;
		//Name the tile in inspector
		TileGameObj.name = "tile_" + x.ToString() + "_" + z.ToString();

		TileGameObj.transform.position = pos;
	}

	private void OnTriggerExit(Collider other) {
		//Check on hex prefab that is convex ON and is trigger ON  -  and have mesh colider
		Destroy(other.gameObject);
	}
}

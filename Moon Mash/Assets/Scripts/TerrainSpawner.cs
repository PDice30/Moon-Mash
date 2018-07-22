using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {

	public GameObject[] trees = new GameObject[10];
	public GameObject planet;
	private float timeUntilTerrainSpawn;
	// Use this for initialization
	void Start () {
		timeUntilTerrainSpawn = SceneConstants.TERRAIN_SPAWN_TIME;
		/* for (int i = 0; i < SceneConstants.NUMBER_OF_TERRAIN_TO_SPAWN; i++) {
			
		} */
		spawnTree ();
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilTerrainSpawn -= Time.deltaTime;
		if (timeUntilTerrainSpawn <= 0) {
			spawnForest (3);
			timeUntilTerrainSpawn = SceneConstants.TERRAIN_SPAWN_TIME;
		}
	}

	private void spawnTree() {


		//GameObject newTree = GameObject.Instantiate (trees [2], planet.transform) as GameObject;
		GameObject newTree = GameObject.Instantiate (trees [0], new Vector3(0,0,0), Quaternion.identity) as GameObject;





		/*
		Vector3 spawnOrigin = getRandomSpawnPointWithRotation (trees [0]);
		/*
		float x = Random.Range (-1f, 1f);
		float y = Random.Range (-1f, 1f);
		float z = Random.Range (-1f, 1f);


		Vector3 spawnPoint = new Vector3 (1, 1, 0).normalized;
		spawnPoint *= (planet.GetComponent<SphereCollider> ().radius * planet.transform.localScale.x);
		// GameObject newTree = GameObject.Instantiate (trees [0], spawnPoint, Quaternion.LookRotation (spawnPoint));
		GameObject newTree = GameObject.Instantiate (trees [0], spawnPoint, Quaternion.LookRotation(spawnPoint)) as GameObject;
		newTree.transform.SetParent (planet.transform);*/
	}

	private void spawnForest(int forestSize) {
		/*
		Vector3 spawnOrigin = spawnOnRandomSpot ();
		for (int i = 0; i < forestSize; i++) {
			float randomNoise = Random.Range (0.1f, 0.3f);
			Vector3 spawnLocation = spawnOrigin * randomNoise;
			int treeType = Random.Range (0, 9);
			GameObject newTree = GameObject.Instantiate (trees [treeType], spawnLocation, Quaternion.LookRotation(spawnOrigin), planet.transform) as GameObject;
			Debug.Log (spawnLocation);
			newTree.transform.Rotate (spawnLocation.normalized);
			newTree.transform.localScale = newTree.transform.localScale * 0.33f;
		}
		*/

		Vector3 spawnOrigin;
		for (int i = 0; i < forestSize; i++) {
			int treeType = Random.Range (0, 9);
			spawnOrigin = getRandomSpawnPointWithRotation (trees [treeType]);
			GameObject newTree = GameObject.Instantiate (trees [treeType], spawnOrigin, Quaternion.LookRotation (spawnOrigin), planet.transform) as GameObject;
			newTree.transform.localScale = newTree.transform.localScale * 0.025f;
		}

	}

	private Vector3 spawnOnRandomSpot() {
		float x = Random.Range (-1f, 1f);
		float y = Random.Range (-1f, 1f);
		float z = Random.Range (-1f, 1f);

		Vector3 spawnPoint = new Vector3 (x, y, z).normalized;
		//Debug.Log (spawnPoint.x + " " + spawnPoint.y + " " + spawnPoint.z + " " + spawnPoint.magnitude);
		// add tree height
		float planetRadius = (planet.GetComponent<SphereCollider> ().radius * planet.transform.localScale.x);
		spawnPoint *= planetRadius;

		return spawnPoint;
	}

	private Vector3 getRandomSpawnPointWithRotation(GameObject terrain, float noiseRange = 3f) {
		float x = Random.Range (-1f, 1f);
		float y = Random.Range (-1f, 1f);
		float z = Random.Range (-1f, 1f);
		float noise = Random.Range (1f, noiseRange);
		Vector3 spawnPoint = new Vector3 (x, y, z).normalized;
		float planetRadius = (planet.GetComponent<SphereCollider> ().radius * planet.transform.localScale.x);
		Debug.Log (planetRadius);
		float terrainHeight = terrain.GetComponent<MeshRenderer> ().bounds.size.y / 5;
		Debug.Log(terrainHeight);
		spawnPoint *= (planetRadius + terrainHeight);
		Debug.Log (spawnPoint);
		// spawnPoint *= noise;
		return spawnPoint;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {

	public GameObject[] trees = new GameObject[10];
	public GameObject planet;
	private float timeUntilTerrainSpawn;
	private int terrainSpawned;
	// Use this for initialization
	void Start () {
		timeUntilTerrainSpawn = SceneConstants.TERRAIN_SPAWN_TIME;
		/* for (int i = 0; i < SceneConstants.NUMBER_OF_TERRAIN_TO_SPAWN; i++) {
			
		} */
		//spawnTree ();
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilTerrainSpawn -= Time.deltaTime;
		if (terrainSpawned<SceneConstants.NUMBER_OF_TERRAIN_TO_SPAWN){
			if (timeUntilTerrainSpawn <= 0) {
				spawnForest (3);
				terrainSpawned=terrainSpawned+3;
				timeUntilTerrainSpawn = SceneConstants.TERRAIN_SPAWN_TIME;
			}
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
        for (int i = 0; i < forestSize; i++) {
			int treeType = Random.Range (0, 9);
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

            Vector3 spawnOrigin = getRandomSpawnPointWithRotation(trees[treeType]);
			Vector3 normalAtTree = getNormalVectorAtSpawn(spawnOrigin);
            GameObject newTree = GameObject.Instantiate (trees [treeType], spawnOrigin, Quaternion.LookRotation (normalAtTree)*Quaternion.Euler(0,90,90), planet.transform) as GameObject;
			newTree.transform.localScale = newTree.transform.localScale * 0.04f;
		}

	}

	private Vector3 getRandomSpawnPointWithRotation(GameObject terrain) {
		float phi = Random.Range (0f, 180f); 	//The angle from the vertical Z axis
		float theta = Random.Range (0f, 360f); 	//The angle around the x axis
		phi = phi * (Mathf.PI/180);				//Convert to radians
		theta = theta * (Mathf.PI/180);			//Convert to radians
		float planetRadius = (planet.GetComponent<SphereCollider> ().radius * planet.transform.localScale.x);

		float x = Mathf.Cos(theta)*Mathf.Sin(phi)*planetRadius;	//Find the x position
		float y = Mathf.Sin(theta)*Mathf.Sin(phi)*planetRadius; //Find the y position
		float z = Mathf.Cos(phi)*planetRadius;					//Find the z position

		Vector3 spawnPoint = new Vector3 (x, y, z);	//Create a vector with the calculated points
		Debug.Log("Phi" + phi);
		Debug.Log("Theta" + theta);
		Debug.Log("PlanetRadius" + planetRadius);
		Debug.Log ("Spawn" + spawnPoint);
		return spawnPoint;
	}

	private Vector3 getNormalVectorAtSpawn(Vector3 spawnPoint){
		float x = spawnPoint.x*2f;
		float y = spawnPoint.y*2f;
		float z = spawnPoint.z*2f;
		Vector3 normalAtSpawn = new Vector3(x,y,z).normalized;
		Debug.Log ("Normal" + normalAtSpawn);
		return normalAtSpawn;
	}
}

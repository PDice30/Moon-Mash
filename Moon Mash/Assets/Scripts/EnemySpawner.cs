using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	private GameObject planet;
	public GameObject enemy;
	private float timeUntilEnemySpawn;

	void Awake() {
		planet = GameObject.Find ("TestPlanet");
	}

	void Start () {
		timeUntilEnemySpawn = SceneConstants.TEST_ENEMY_SPAWN_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilEnemySpawn -= Time.deltaTime;
		if (timeUntilEnemySpawn <= 0) {
			GameObject newEnemy = GameObject.Instantiate (enemy, spawnOnRandomSpot(), Quaternion.identity) as GameObject;
			newEnemy.transform.SetParent (planet.transform);
			timeUntilEnemySpawn = SceneConstants.TEST_ENEMY_SPAWN_TIME;
		}
	}

	private Vector3 spawnOnRandomSpot() {
		float x = Random.Range (-1f, 1f);
		float y = Random.Range (-1f, 1f);
		float z = Random.Range (-1f, 1f);

		Vector3 spawnPoint = new Vector3 (x, y, z).normalized;
		//Debug.Log (spawnPoint.x + " " + spawnPoint.y + " " + spawnPoint.z + " " + spawnPoint.magnitude);
		float planetRadius = (planet.GetComponent<SphereCollider> ().radius * planet.transform.localScale.x) 
			+ (enemy.GetComponent<SphereCollider>().radius * 2);
		spawnPoint *= planetRadius;

		return spawnPoint;
	}
}

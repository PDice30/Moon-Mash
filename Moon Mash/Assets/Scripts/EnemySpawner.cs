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
		timeUntilEnemySpawn = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilEnemySpawn -= Time.deltaTime;
		if (timeUntilEnemySpawn <= 0) {
			GameObject newEnemy = GameObject.Instantiate (enemy, planet.transform) as GameObject;
			timeUntilEnemySpawn = 2.0f;
		}
	}
}

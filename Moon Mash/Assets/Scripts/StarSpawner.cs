using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

	// Use this for initialization
	private PlaySceneController playSC;
	public GameObject starPrefab;

	private float timeUntilNextStarSpawn = 0.01f;

	void Awake () {
		playSC = GameObject.Find ("PlaySceneController").GetComponent<PlaySceneController>() as PlaySceneController;

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playSC.isWarpingToPlanet) {
			timeUntilNextStarSpawn -= Time.deltaTime;
			if (timeUntilNextStarSpawn <= 0) {
				GameObject newStar = GameObject.Instantiate (starPrefab, getStarSpawnPos(), Quaternion.identity) as GameObject;
				newStar.transform.localScale = getStarScale ();
				newStar.AddComponent<MiscObjectMover> ();
				timeUntilNextStarSpawn = 0.01f;
			}
		}
	}

	private Vector3 getStarSpawnPos() {
		float x = Random.Range (-12f, 12f);
		float y = 40f;
		float z = Random.Range (12f, 18f);

		return new Vector3 (x, y, z);
	}

	private Vector3 getStarScale() {
		float scale = Random.Range (0.05f, .5f);

		return new Vector3 (scale, scale, scale);
	}
}

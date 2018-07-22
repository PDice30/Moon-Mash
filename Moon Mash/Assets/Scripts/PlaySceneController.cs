using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneController : MonoBehaviour {

	// Use this for initialization
	public Camera mainCamera;
	private Animator mainCameraAnimator;

	private StarSpawner starSpawner;
	private TerrainSpawner terrainSpawner;

	public GameObject currentPlanet;
	public GameObject background;

	public float playerShipSpeed = 0.0f;

	public bool isWarpingToPlanet = false;

	void Awake() {
		starSpawner = GameObject.Find ("StarSpawnerObj").GetComponent<StarSpawner>() as StarSpawner;
		terrainSpawner = GameObject.Find ("TerrainSpawnerObj").GetComponent<TerrainSpawner>() as TerrainSpawner;
	}

	void Start () {
		mainCameraAnimator = mainCamera.GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim_triggerPlanetZoom ();
		}
		if (isWarpingToPlanet) {
			if (playerShipSpeed >= 150) {
				playerShipSpeed = 150;
			} else {
				playerShipSpeed += 1f;
			}
		}
	}


	public void anim_triggerPlanetZoom() {
		mainCameraAnimator.SetTrigger ("SpacePressedTest");
		background.GetComponent<Animator> ().SetTrigger ("SpacePressedTest");
	}

	//Might not actually be anim
	public void anim_triggerPlanetWarp() {
		MiscObjectMover mover = currentPlanet.AddComponent<MiscObjectMover> ();

		isWarpingToPlanet = true;
	}
}

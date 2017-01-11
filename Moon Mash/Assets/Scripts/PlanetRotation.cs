using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

	PlayerController playerController;
	// Use this for initialization

	void Awake() {
		playerController = GameObject.Find ("PlayerController").GetComponent<PlayerController> () as PlayerController;
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.Rotate (new Vector3 (0, 0.2f, 0.2f));
			
	}
	/*
	void OnMouseDown() {
		playerController.handlePlanetRotation(
	}
	*/
}

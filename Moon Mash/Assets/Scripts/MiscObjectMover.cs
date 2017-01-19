using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscObjectMover : MonoBehaviour {

	// Use this for initialization
	private PlaySceneController playSC;

	void Awake () {
		playSC = GameObject.Find ("PlaySceneController").GetComponent<PlaySceneController>() as PlaySceneController;

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * playSC.playerShipSpeed, Space.World);
		if (transform.position.y <= -20) {
			Destroy (gameObject);
		}
	}
}

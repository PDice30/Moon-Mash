using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	public PlaySceneController playSC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void cameraZoomOutFinished() {
		Debug.Log ("CameraZoomOut finished");
		playSC.anim_triggerPlanetWarp ();
	}
}

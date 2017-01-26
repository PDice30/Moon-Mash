using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	Transform planet;
	Vector3 currentTouchPos;
	Vector3 previousTouchPos;

	void Awake() {
		planet = GameObject.Find ("TestPlanet").transform;
	}

	void Start () {
		currentTouchPos = Vector3.zero;
		previousTouchPos = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			previousTouchPos = Input.mousePosition;
			currentTouchPos = Input.mousePosition;
		}
		if (Input.GetButton ("Fire1")) {
			handlePlanetRotation (Input.mousePosition);
		}
	}


	public void handlePlanetRotation(Vector3 touchPos) {
		//Debug.Log ("x = " + touchPos.x + " y = " + touchPos.y + " z = " + touchPos.z);
		/*
		if (currentTouchPos == Vector3.zero && previousTouchPos == Vector3.zero) {
			currentTouchPos = touchPos;
			previousTouchPos = touchPos;
		}
*/

		//LUL HACKS

		currentTouchPos = touchPos;

		Vector3 moveVector = currentTouchPos - previousTouchPos;
		//moveVector.Normalize ();
		moveVector = new Vector3 (moveVector.y, -moveVector.x, moveVector.z);
		moveVector = moveVector / 2;
		planet.Rotate (moveVector, Space.World);


		//planet.transform.rotation = Quaternion.FromToRotation (previousTouchPos, currentTouchPos);

		previousTouchPos = touchPos;
	}
}

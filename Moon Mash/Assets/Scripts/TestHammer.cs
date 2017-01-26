using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHammer : MonoBehaviour {

	// Use this for initialization
	float timeUntilNextSmash = 5.0f;

	public Animator testHammerAC;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNextSmash -= Time.deltaTime;
		if (timeUntilNextSmash <= 0) {
	

			triggerSmash ();
			timeUntilNextSmash = 5.0f;
			Debug.Log ("SMASH");
		}

	}

	void triggerSmash() {
		testHammerAC.SetTrigger ("SmashReady");
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Enemy") {
			Destroy (coll.gameObject);
		}
	}
}

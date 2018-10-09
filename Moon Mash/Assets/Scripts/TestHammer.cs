using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHammer : MonoBehaviour {

	// Use this for initialization
	float timeUntilNextSmash = 2.0f;

	public EnemySpawner enemySpawner;
	// This is not a good implementation at all.
	public List<GameObject> _enemies;
	public Animator testHammerAC;

	void Start () {
		_enemies = enemySpawner.enemies;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNextSmash -= Time.deltaTime;
		if (timeUntilNextSmash <= 0) {
	

			triggerSmash ();
			timeUntilNextSmash = 2.0f;
			Debug.Log ("SMASH");
		}

	}

	void triggerSmash() {
		testHammerAC.SetTrigger ("SmashReady");
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Enemy") {
			_enemies.Remove(coll.gameObject);
			Destroy (coll.gameObject);
		}
	}
}

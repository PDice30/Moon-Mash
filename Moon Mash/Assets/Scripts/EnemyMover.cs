using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	// Use this for initialization
	public Rigidbody rigidBody;
	private ConstantForce cForce;

	private float timeUntilNextMove = 1.0f;

	void Awake() {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
	}

	void Start () {
		cForce = gameObject.AddComponent<ConstantForce> ();
		//cForce.relativeForce = ((transform.parent.position - transform.position).normalized * 10);
	}
	
	// Update is called once per frame
	void Update () {
		/*cForce.force.Set (transform.position.x - transform.parent.position.x,
			transform.position.y - transform.parent.position.y,
			transform.position.z - transform.parent.position.z);
			*/


		cForce.force = ((transform.parent.position - transform.position).normalized * 20);

		/*Debug.Log ((transform.position.x - transform.parent.position.x) + " " +
			(transform.position.y - transform.parent.position.y) + " " +
			(transform.position.z - transform.parent.position.z));
		
		Debug.Log (cForce.force.x + " " + cForce.force.y + " " + cForce.force.z);
*/
		timeUntilNextMove -= Time.deltaTime;
		if (timeUntilNextMove <= 0) {
			rigidBody.AddForce(generateRandomVector() * 40);
			timeUntilNextMove = 1.0f;
		}
	}

	//Should be global
	public Vector3 generateRandomVector() {
		//Not truly random, orientied towards poles likely
		return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
	}
}

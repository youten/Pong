using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour {

	void OnCollisionEnter (Collision col) {
		Rigidbody rb = GetComponent<Rigidbody> ();
		if (rb != null) {
			// change x-axis bound randomly
			if (Random.Range(0, 5) == 0) {
				rb.velocity = new Vector3(Random.Range(-5.0f, 5.0f),
			    	                      0,
			        	                  rb.velocity.z * 1.03f);
			} else {
				rb.velocity = new Vector3(rb.velocity.x * 1.01f + Random.Range(0.0f, 0.04f),
				                          0,
				                          rb.velocity.z * 1.03f);
			}
		}
	}
}

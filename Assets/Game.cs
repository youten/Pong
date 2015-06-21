using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private GameObject ballPrefab;
	private GameObject ball;

	// Use this for initialization
	void Start () {
		ballPrefab = (GameObject) Resources.Load ("Pong/Ball");	
		generateBall ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void generateBall() {
		Vector3 pos = new Vector3 (transform.position.x,
		                                   transform.position.y,
		                                   transform.position.z + 1.0f);
		ball = (GameObject) Instantiate (ballPrefab, pos, transform.rotation);
		Rigidbody rb = ball.GetComponent<Rigidbody> ();
		if (rb != null) {
			rb.velocity = new Vector3(Random.Range (-5.0f, 5.0f), // x
			            0,                          // y
			            5.0f);                      // z
		}
	}

}

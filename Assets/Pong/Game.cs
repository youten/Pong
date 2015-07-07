using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public static float MAX_ME_X = 7.5f;
	private GameObject ballPrefab;
	private GameObject ball;

	// Use this for initialization
	void Start () {
		ballPrefab = (GameObject) Resources.Load ("Pong/Ball");
		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
		// key
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			if (-MAX_ME_X < transform.position.x) {
				transform.Translate(Vector3.left * 0.2f);
			}
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			if (transform.position.x < MAX_ME_X) {
				transform.Translate(Vector3.right * 0.2f);
			}
		}
	}

	void startGame () {
		Singleton<SePlayer>.instance.play ("op");
		generateBall ();
	}

	// message
	void OnBallFell () {
		startGame ();
	}

	void generateBall() {
		if (ball != null) {
			Destroy(ball);
		}
		Vector3 pos = new Vector3 (transform.position.x,
		                                   transform.position.y,
		                                   transform.position.z + 1.0f);
		ball = (GameObject) Instantiate (ballPrefab, pos, transform.rotation);

		Rigidbody rb = ball.GetComponent<Rigidbody> ();
		if (rb != null) {
			rb.velocity = new Vector3(Random.Range (-5.0f, 5.0f), // x
			            0,                          // y
			            10.0f);                     // z
		}
	}
	
}

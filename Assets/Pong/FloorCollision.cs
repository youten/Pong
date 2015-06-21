using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour {
	public GameObject MeObject;

	void OnCollisionEnter (Collision col) {
		MeObject.SendMessage ("OnBallFell");
	}
}

using UnityEngine;
using System.Collections;

public class MeHead : MonoBehaviour {
	public GameObject MeObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion head = Cardboard.SDK.HeadRotation;
		float posX = head.y * 20.0f;
		if (posX < -Game.MAX_ME_X) {
			posX = -Game.MAX_ME_X;
		} else if (Game.MAX_ME_X < posX) {
			posX = Game.MAX_ME_X;
		}
		// move bar
		MeObject.transform.position =
			new Vector3 (posX,
			             MeObject.transform.position.y,
			             MeObject.transform.position.z);
		// move camera
		transform.position = 
			new Vector3 (posX / 2.0f,
			             transform.position.y,
			             transform.position.z);
	}
}

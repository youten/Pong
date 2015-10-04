// Head Tracking Script for Gear VR
using UnityEngine;
using UnityEngine.VR; // added
using System.Collections;

public class MeHeadVR : MonoBehaviour {
	public GameObject MeObject;
	public GameObject CameraParentObject;
	
	// Update is called once per frame
	void Update () {
		Quaternion head = InputTracking.GetLocalRotation (VRNode.Head); // changed
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
		if (CameraParentObject != null) {
			CameraParentObject.transform.position = 
				new Vector3 (posX / 2.0f,
				             CameraParentObject.transform.position.y,
				             CameraParentObject.transform.position.z);
		}
	}
}

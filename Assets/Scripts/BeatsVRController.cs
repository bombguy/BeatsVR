using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsVRController : MonoBehaviour {


	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	Transform contactTarget = null;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		device = SteamVR_Controller.Input ((int)trackedObject.index);
	}

	void fire (bool line_of_sight, RaycastHit hit) {
		if (line_of_sight) {
			device.TriggerHapticPulse (3000);
			Debug.Log ("Target HIT");
			Destroy (hit.transform.gameObject);
		}
	}

	void checkAim(bool line_of_sight, RaycastHit hit) {
		if (!line_of_sight || (contactTarget && contactTarget != hit.transform))
		{
			if (contactTarget != null)
				contactTarget.GetComponent<TargetBehavior> ().isTarget = false;
			contactTarget = null;
		}
		if (line_of_sight) {
			hit.transform.GetComponent<TargetBehavior> ().isTarget = true;
			contactTarget = hit.transform;
		}
	}

	void checkCollide(bool bHit, RaycastHit hit)
	{
		//reset if beam not hitting or hitting new target

		/*if (!bHit || (contactTarget && contactTarget != hit.transform))
		{
			if (contactTarget != null)
				changeColor (contactTarget.transform.gameObject, Color.black);
			contactTarget = null;
		}*/

		//check if beam has hit a new target
		if (bHit)
		{
			device.TriggerHapticPulse (3000);
			DestroyObject (hit.transform.gameObject);
			//changeColor (hit.transform.gameObject, Color.green);
			//contactTarget = hit.transform;
		}
	}

	void changeColor (GameObject obj, Color color) {
		obj.GetComponent<Renderer> ().material.color = color;
	}

	void Update() {
		Ray raycast = new Ray (transform.position, transform.forward);
		RaycastHit hitObject;
		bool rayHit = Physics.Raycast (raycast, out hitObject);

		checkAim (rayHit, hitObject);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			fire (rayHit, hitObject);
		}


	}

} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsVRController : MonoBehaviour {


	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	Transform contactTarget = null;

	public LineRenderer laser;
	public float laser_length = 100f;

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

	void Update() {
		//Debug.Log (transform.forward);
		laser.SetPosition(0, transform.position);
		laser.SetPosition (1, DetectHit (transform.position, laser_length, transform.forward));

		Vector3 newvector = transform.eulerAngles;
		newvector.z -= 90;

		Ray raycast = new Ray (transform.position, transform.forward);
		RaycastHit hitObject;
		bool rayHit = Physics.Raycast (raycast, out hitObject);

		checkAim (rayHit, hitObject);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			fire (rayHit, hitObject);
		}


	}

	Vector3 DetectHit(Vector3 startPos, float distance, Vector3 direction) {
		Ray ray = new Ray (startPos, direction);
		RaycastHit hit;
		Vector3 endPos = startPos + (distance * direction);
		if (Physics.Raycast (ray, out hit, distance)) {
			endPos = hit.point;
			return endPos;
		}

		return endPos;
	}
} 

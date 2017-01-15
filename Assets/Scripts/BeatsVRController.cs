using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatsVRController : MonoBehaviour {

	private ScoreSystem score_system;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	Transform contactTarget = null;

	public LineRenderer laser;
	public float laser_length = 100f;

	private bool isActiveGame;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		device = SteamVR_Controller.Input ((int)trackedObject.index);

		isActiveGame = SceneManager.GetActiveScene ().name.Equals ("main");

		if (isActiveGame)
			score_system = GameObject.Find ("ScoreSystem").GetComponent<ScoreSystem>();

	}

	void fire (bool line_of_sight, RaycastHit hit) {
		gameObject.GetComponent<AudioSource> ().Play ();
		if (line_of_sight) {
			if (hit.transform.tag == "UI") {
				SceneManager.LoadSceneAsync("main");
				return;
			}

			device.TriggerHapticPulse (3000);
			score_system.score++;
			score_system.combo++;

			score_system.CreateText (hit.transform.position, transform.rotation);
			Destroy (hit.transform.gameObject);
		} else if (isActiveGame){
			score_system.combo = 0;
		}
	}

	void checkAim(bool line_of_sight, RaycastHit hit) {
		if (!line_of_sight || (contactTarget && contactTarget != hit.transform))
		{
			if (contactTarget != null)
				contactTarget.GetComponent<TargetBehavior> ().isTarget = false;
			contactTarget = null;
		}
		if (line_of_sight && isActiveGame) {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsVRController : MonoBehaviour {


	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}

	void Trigger (object sender, ClickedEventArgs e)
	{
		Debug.Log ("Trigger Clicked");
	}


	// Update is called once p..........,
	void Update() {
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		if (device.GetAxis().x != 0 || device.GetAxis().y != 0) {
			//Debug.Log (device.GetAxis().x + " " + device.GetAxis ().y);
		}
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Trigger Press");
			device.TriggerHapticPulse(3999);
			Debug.Log (device.GetAxis().x + " " + device.GetAxis ().y);
		}
	}

} 

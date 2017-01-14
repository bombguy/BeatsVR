using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {

	public bool isTarget;
	public float lifespan;

	private float timer;


	void Start() {
		isTarget = false;
	}
	
	void Update () {
		if (isTarget) {
			this.gameObject.transform.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			this.gameObject.transform.GetComponent<Renderer> ().material.color = Color.cyan;
		}
		timer += Time.deltaTime;


		if (timer > lifespan) {
			Destroy (this.gameObject);
		}
	}
}

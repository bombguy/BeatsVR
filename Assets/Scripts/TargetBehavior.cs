using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {

	public bool isTarget;
	public float lifespan;

	private float timer;
	public Color default_color;
	public Color highlight_color;

	void Start() {
		isTarget = false;
	}
	
	void Update () {
		if (isTarget) {
			this.gameObject.transform.GetComponent<Renderer> ().material.color = highlight_color;
		} else {
			this.gameObject.transform.GetComponent<Renderer> ().material.color = default_color;
		}
		timer += Time.deltaTime;


		if (timer > lifespan) {
			Destroy (this.gameObject);
		}
	}
}

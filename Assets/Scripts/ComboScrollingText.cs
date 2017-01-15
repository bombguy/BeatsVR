using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScrollingText : MonoBehaviour {

	public float fadeTime;
	private float timer;


	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > fadeTime)
			Destroy (gameObject);
	}
}

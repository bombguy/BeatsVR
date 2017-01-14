using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject target_prefab;
	public double spawn_rate;

	private double timer;

	// Use this for initialization
	void Start () {
		timer = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawn_rate) {
			timer = 0;

			Vector3 pos = new Vector3 (Random.Range (0f, 1f), Random.Range (1f, 2f), Random.Range (-0.5f, -1f));
			Instantiate (target_prefab, pos, Quaternion.identity);
		}
	}
}

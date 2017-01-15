using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject target_prefab;
	public double spawn_rate;
	public float spawn_radius;

	public Transform player;
	private double timer;

	// Use this for initialization
	void Start () {
		player = Camera.main.transform;
		timer = 0;	
	}

	Vector3 newCoord() {
		float distance, x, y, z;
		do {
			x = Random.Range (-spawn_radius, spawn_radius);
			y = Random.Range (1, spawn_radius);
			z = Random.Range (-spawn_radius, spawn_radius);
			distance = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2) + Mathf.Pow (z, 2));
		} while (Mathf.Abs (spawn_radius - distance) < 1);
		//Debug.Log (x + " " + y + " " + z + " " + distance);
		return new Vector3 (x, y, z) + player.position;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawn_rate) {
			timer = 0;
			Instantiate (target_prefab, newCoord(), Quaternion.identity);
		}
	}
}

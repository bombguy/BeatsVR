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
		float x, y, z;
		float side = Random.Range(-1f, 1f);
		if (side >= 0) {
			x = Random.Range(-1f, 0);
			z = Random.Range(-1f, 0);
			y = Random.Range(0, 1f);
		}
		else {
			x = Random.Range(0, 1f);
			z = Random.Range(-1f, 0);
			y = Random.Range(0, 1f);
		}
		return new Vector3 (x * spawn_radius, y * spawn_radius, z * spawn_radius) + player.position;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawn_rate) {
			timer = 0;
			Instantiate (target_prefab, newCoord(), Quaternion.identity);
			Debug.Log (transform.forward);
		}
	}
}

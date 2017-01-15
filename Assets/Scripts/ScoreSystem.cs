using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

	public int score;
	public int combo;
	public int max_combo;


	public float max_game_duration;

	public GameObject textPrefab;


	private float timer;

	// Use this for initialization
	void Start () {
		score = 0;
		combo = 0;
		timer = 0;
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer > max_game_duration) {
			
		}
		if (combo > max_combo)
			max_combo = combo;
	}

	public void CreateText(Vector3 position, Quaternion rot) {
		GameObject newLabel = (GameObject)Instantiate (textPrefab, position, rot);
		newLabel.GetComponent<TextMesh> ().text = "Combo\n" + combo.ToString();
	}
}

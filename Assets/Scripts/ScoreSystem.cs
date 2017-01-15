using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreSystem : MonoBehaviour {

	public int score;
	public int combo;
	public int max_combo;
	public int max_targets;

	public float max_game_duration;

	public GameObject textPrefab;

	private float timer;

	// Use this for initialization
	void Start () {
		max_targets = 0;
		score = 0;
		combo = 0;
		timer = 0;
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer > max_game_duration) {
			Debug.Log ("End of Game " + max_targets);

			GlobalData.Instance.max_combo = this.max_combo;
			GlobalData.Instance.score = this.score;
			GlobalData.Instance.accuracy = this.score / (float)(this.max_targets);

			SceneManager.LoadScene ("scoremenu");
		}
		if (combo > max_combo)
			max_combo = combo;
	}

	public void CreateText(Vector3 position, Quaternion rot) {
		GameObject newLabel = (GameObject)Instantiate (textPrefab, position, rot);
		newLabel.GetComponent<TextMesh> ().text = "Combo\n" + combo.ToString();
	}
}

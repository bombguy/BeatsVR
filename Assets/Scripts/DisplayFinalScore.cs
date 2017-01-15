using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFinalScore : MonoBehaviour {

	private GameObject UI;

	void Start() {
		GameObject.Find ("Score").GetComponent<TextMesh> ().text = GlobalData.Instance.score.ToString();
		GameObject.Find ("Combo").GetComponent<TextMesh> ().text = GlobalData.Instance.max_combo.ToString();
		GameObject.Find ("Accuracy").GetComponent<TextMesh> ().text = (Mathf.Round((GlobalData.Instance.accuracy * 100) * 100f) / 100f).ToString() + "%"; 
	}


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {

	public static GlobalData Instance;

	public int max_combo;
	public int score;
	public float accuracy;

	void Start() {
		max_combo = 0;
		score = 0;
		accuracy = 0;
	}

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	} 
}
